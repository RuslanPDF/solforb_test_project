using System.Reflection;
using Application.Common.Persistence;
using AutoMapper.Internal;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostgresqlDbContext _context;
    
    private static readonly Dictionary<Type, Type> InterfaceImplementationMap = new();
    private readonly Dictionary<Type, object> _interfaceInstanceMap = new();
    
    public static void Init()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var repositories = assembly
            .GetTypes()
            .Where(x => 
                x is { IsClass: true, IsAbstract: false, IsPublic: true } && 
                x.GetGenericInterface(typeof(IRepository<>)) != null);

        foreach (var item in repositories)
        {
            if (item.GetConstructor(new[] { typeof(DbContext) }) is null)
            {
                throw new ApplicationException($"Repository {item.Name} not registered: can't find valid constructor");
            }
            
            var repositoryInterface = item
                .GetInterfaces()
                .FirstOrDefault(x => x
                    .GetInterfaces()
                    .Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IRepository<>)));

            if (repositoryInterface != null)
            {
                InterfaceImplementationMap.Add(repositoryInterface, item);
            }
            else
            {
                throw new ApplicationException($"Repository {item.Name} not registered: Unable to find a valid IRepository<> interface implemented by the class");
            }
        }
    }
    
    public UnitOfWork(PostgresqlDbContext context)
    {
        _context = context;
    }
    
    public TRepository GetRepository<TRepository>() where TRepository : IRepository
    {
        if (_interfaceInstanceMap.TryGetValue(typeof(TRepository), out var repo))
        {
            return (TRepository)repo;
        }

        if (!InterfaceImplementationMap.TryGetValue(typeof(TRepository), out var implType))
        {
            throw new ApplicationException($"Implementation for {typeof(TRepository)} not register");
        }
        
        var instance = Activator.CreateInstance(implType, _context);
        if (instance is null)
        {
            throw new ApplicationException($"Can't create instance for {implType}");
        }

        _interfaceInstanceMap.Add(typeof(TRepository), instance);
        return (TRepository)instance;
    }

    public async Task CommitAsync(CancellationToken token = default)
    {
        var entries = _context.ChangeTracker
            .Entries()
            .Where(e => e is { Entity: Entity, State: EntityState.Added or EntityState.Modified });

        foreach (var entityEntry in entries)
        {
            ((Entity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

            if (entityEntry.State != EntityState.Added)
            {
                continue;
            }
            
            if (((Entity)entityEntry.Entity).CreatedAt == default)
            {
                ((Entity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;   
            }
        }
        
        await _context.SaveChangesAsync(token);
    }
}
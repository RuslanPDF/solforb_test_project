using Application.Common.Exceptions;
using Application.Common.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public abstract class BaseRepository<TBase> : IRepository<TBase> where TBase : Entity, new()
{
    protected readonly DbSet<TBase> Entities;

    public BaseRepository(DbContext context)
    {
        Entities = context.Set<TBase>();
    }
    
    public virtual async Task Insert(TBase entity)
    {
        await Entities.AddAsync(entity);
    }

    public virtual async Task InsertRange(IEnumerable<TBase> entities)
    {
        await Entities.AddRangeAsync(entities);
    }

    public virtual Task<TBase?> GetById(int id)
    {
        return Entities.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<TBase> GetByIdOrFail(int id)
    {
        var entity = await Entities.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            throw new EntityNotFoundException(nameof(TBase), nameof(id), id);
        }

        return entity;
    }

    public virtual void Remove(TBase entity)
    {
        Entities.Remove(entity);
    }

    public virtual void RemoveById(int id)
    {
        Entities.Remove(new TBase { Id = id });
    }

    public void RemoveRange(ICollection<TBase> entities)
    {
        Entities.RemoveRange(entities);
    }
}
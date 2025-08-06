using Application.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddDbContext<PostgresqlDbContext>(opt => opt.UseNpgsql(config.GetConnectionString("PostgresqlContext")));
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        
        UnitOfWork.Init();
    }
}
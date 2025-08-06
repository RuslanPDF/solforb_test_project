using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class PostgresqlDbContext : DbContext
{
    public PostgresqlDbContext(DbContextOptions<PostgresqlDbContext> opt) : base(opt) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresqlDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
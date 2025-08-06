using Domain.Entities;

namespace Application.Common.Persistence;

public interface IRepository<TEntity> : IRepository where TEntity : Entity
{
    public Task Insert(TEntity entity);
    public Task InsertRange(IEnumerable<TEntity> entities);

    public Task<TEntity?> GetById(int id);
    public Task<TEntity> GetByIdOrFail(int id);
    
    public void Remove(TEntity entity);
    public void RemoveById(int id);
    public void RemoveRange(ICollection<TEntity> entities);
}

public interface IRepository { }

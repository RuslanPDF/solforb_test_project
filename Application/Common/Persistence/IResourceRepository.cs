using Domain.Entities;

namespace Application.Common.Persistence;

public interface IResourceRepository : IRepository<Resource>
{
    public Task<List<Resource>> GetAllAsync();
    public Task<Resource> GetByIdAsync(int id);
    public Task CheckNameExists(string name);
}
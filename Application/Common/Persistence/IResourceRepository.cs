using Domain.Entities;

namespace Application.Common.Persistence;

public interface IResourceRepository : IRepository<Resource>
{
    public Task<List<Resource>> GetAllAsync(string status);
    public Task CreateResource(Resource resource);
    public Task<Resource> GetByIdAsync(int id);
    public Task CheckNameExists(string name);
}
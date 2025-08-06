using Application.Common.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class ResourceRepository(DbContext ctx) : BaseRepository<Resource>(ctx), IResourceRepository
{
    public async Task<List<Resource>> GetAllAsync()
    {
        return await Entities.ToListAsync();
    }

    public async Task<Resource> GetByIdAsync(int id)
    {
        var resource = await Entities.FirstOrDefaultAsync(x => x.Id == id);
        if (resource == null)
        {
            throw new Exception(RepositoryConstants.NOT_FOUND_RESOURCE_BY_ID + id);
        }

        return resource;
    }


    public async Task CreateResource(Resource resource)
    {
        await Entities.AddAsync(resource);
        try
        {
            await ctx.SaveChangesAsync();
        }
        catch
        {
            throw new Exception(RepositoryConstants.ERROR_CREATING_RECORD);
        }
    }

    public async Task CheckNameExists(string name)
    {
        var resource = await Entities.FirstOrDefaultAsync(x => x.Name == name);
        if (resource != null)
        {
            throw new Exception(RepositoryConstants.NAME_EXISTS);
        }
    }
}
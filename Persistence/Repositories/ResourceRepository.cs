using Application.Common.Exceptions;
using Application.Common.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class ResourceRepository(DbContext ctx) : BaseRepository<Resource>(ctx), IResourceRepository
{
    public async Task<List<Resource>> GetAllAsync(string status)
    {
        var query = Entities.AsQueryable();

        switch (status)
        {
            case "all":
            {
                return await Entities
                    .ToListAsync();
            }
            case "true":
            case "false":
            {
                var parseStatus = bool.Parse(status);
                return await Entities
                    .Where(x => x.Status == parseStatus)
                    .ToListAsync();
            }
        }
        
        throw new BadRequestException("Server error");
    }

    public async Task<Resource> GetByIdAsync(int id)
    {
        var resource = await Entities.FirstOrDefaultAsync(x => x.Id == id);
        if (resource == null)
        {
            throw new BadRequestException(RepositoryConstants.NOT_FOUND_RESOURCE_BY_ID + id);
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
            throw new BadRequestException(RepositoryConstants.ERROR_CREATING_RECORD);
        }
    }

    public async Task CheckNameExists(string name)
    {
        var resource = await Entities.FirstOrDefaultAsync(x => x.Name == name);
        if (resource != null)
        {
            throw new BadRequestException(RepositoryConstants.NAME_EXISTS);
        }
    }
}
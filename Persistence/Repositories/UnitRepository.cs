using Application.Common.Exceptions;
using Application.Common.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class UnitRepository(DbContext ctx) : BaseRepository<UnitOfMeasurement>(ctx), IUnitRepository
{
    public async Task<List<UnitOfMeasurement>> GetAllAsync(string status)
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

    public async Task<UnitOfMeasurement> GetByIdAsync(int id)
    {
        var unit = await Entities.FirstOrDefaultAsync(x => x.Id == id);
        if (unit == null)
        {
            throw new BadRequestException(RepositoryConstants.NOT_FOUND_UNIT_BY_ID + id);
        }

        return unit;
    }


    public async Task CreateUnit(UnitOfMeasurement unit)
    {
        await Entities.AddAsync(unit);
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
        var unit = await Entities.FirstOrDefaultAsync(x => x.Name == name);
        if (unit != null)
        {
            throw new BadRequestException(RepositoryConstants.NAME_EXISTS);
        }
    }
}
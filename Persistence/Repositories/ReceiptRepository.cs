using Application.Common.DTOs.Filter;
using Application.Common.DTOs.Request.Receipts;
using Application.Common.Exceptions;
using Application.Common.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class ReceiptRepository(DbContext ctx) : BaseRepository<ReceiptDocument>(ctx), IReceiptRepository
{
    public async Task<List<ReceiptDocument>> GetAllAsync(ReceiptFilter filter)
    {
        var query = Entities.AsQueryable();

        if (filter.DateFrom.HasValue)
            query = query.Where(x => x.Date >= filter.DateFrom.Value);

        if (filter.DateTo.HasValue)
            query = query.Where(x => x.Date <= filter.DateTo.Value);

        if (filter.Numbers != null && filter.Numbers.Any())
            query = query.Where(x => filter.Numbers.Contains(x.Number));

        if (filter.ResourceIds != null && filter.ResourceIds.Any())
        {
            query = query.Where(x => x.ReceiptResources.Any(r => filter.ResourceIds.Contains(r.ResourceId)));
        }

        if (filter.UnitIds != null && filter.UnitIds.Any())
        {
            query = query.Where(x => x.ReceiptResources.Any(r => filter.UnitIds.Contains(r.UnitOfMeasurementId)));
        }

        return await query.Include(x => x.ReceiptResources).ToListAsync();
    }


    public async Task<ReceiptDocument> GetByIdAsync(int id)
    {
        var receipt = await Entities.Include(x => x.ReceiptResources).FirstOrDefaultAsync(x => x.Id == id);
        if (receipt == null)
        {
            throw new BadRequestException(RepositoryConstants.NOT_FOUND_RECEIPT_BY_ID + id);
        }

        return receipt;
    }


    public async Task CreateReceipt(ReceiptDocument receipt)
    {
        await Entities.AddAsync(receipt);
        try
        {
            await ctx.SaveChangesAsync();
        }
        catch
        {
            throw new BadRequestException(RepositoryConstants.ERROR_CREATING_RECORD);
        }
    }

    public async Task CheckNumberExists(string number)
    {
        var receipt = await Entities.FirstOrDefaultAsync(x => x.Number == number);
        if (receipt != null)
        {
            throw new BadRequestException(RepositoryConstants.NUMBER_EXISTS);
        }
    }
}
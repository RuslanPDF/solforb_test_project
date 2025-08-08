using Application.Common.DTOs.Filter;
using Domain.Entities;

namespace Application.Common.Persistence;

public interface IReceiptRepository : IRepository<ReceiptDocument>
{
    public Task<List<ReceiptDocument>> GetAllAsync(ReceiptFilter filter);
    public Task CreateReceipt(ReceiptDocument resource);
    public Task<ReceiptDocument> GetByIdAsync(int id);
    public Task CheckNumberExists(string number);
}
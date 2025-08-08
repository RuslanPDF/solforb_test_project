using Domain.Entities;
using MediatR;

namespace Application.Receipts.Queries.GetReceiptById;

public record GetReceiptByIdQry : IRequest<ReceiptDocument>
{
    public int Id { get; init; }
}
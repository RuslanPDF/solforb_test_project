using Application.Common.DTOs.Response;
using Application.Common.DTOs.Response.Receipt;
using MediatR;

namespace Application.Receipts.Queries.GetReceiptById;

public record GetReceiptByIdQry : IRequest<ReceiptDocumentResponse>
{
    public int Id { get; init; }
}
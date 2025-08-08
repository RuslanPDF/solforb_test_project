using Application.Common.DTOs.Response;
using Application.Common.DTOs.Response.Receipt;
using MediatR;

namespace Application.Receipts.Queries.GetReceiptAll;

public record GetReceiptAllQry : IRequest<List<ReceiptDocumentResponse>>
{
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public List<string>? Numbers { get; set; } = [];
    public List<int>? ResourceIds { get; set; } = [];
    public List<int>? UnitIds { get; set; } = [];
}
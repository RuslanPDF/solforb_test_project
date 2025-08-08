using Domain.Entities;
using MediatR;

namespace Application.Receipts.Queries.GetReceiptAll;

public record GetReceiptAllQry : IRequest<List<ReceiptDocument>>
{
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public List<string>? Numbers { get; set; } = [];
    public List<int>? ResourceIds { get; set; } = [];
    public List<int>? UnitIds { get; set; } = [];
}
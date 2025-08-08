using Application.Common.DTOs.Request.Resources;
using MediatR;

namespace Application.Receipts.Commands.UpdateReceiptById;

public class UpdateReceiptByIdCmd : IRequest
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public List<ResourceItemRequest> Items { get; set; } = [];
}
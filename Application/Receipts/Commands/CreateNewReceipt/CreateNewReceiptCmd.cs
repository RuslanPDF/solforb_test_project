using Application.Common.DTOs.Request.Resources;
using MediatR;

namespace Application.Receipts.Commands.CreateNewReceipt;

public class CreateNewReceiptCmd: IRequest
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public List<ResourceItemRequest> Items { get; set; } = [];
}
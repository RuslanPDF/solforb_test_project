using Application.Common.DTOs.Request.Resources;

namespace Application.Common.DTOs.Request.Receipts;

public class CreateNewReceiptRequest
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    public List<ResourceItemRequest> Items { get; set; } = [];
}
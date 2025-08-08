namespace Application.Common.DTOs.Response.Receipt;

public class ReceiptDocumentResponse
{
    public string Number { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public List<ReceiptResourceResponse> ReceiptResources { get; set; } = [];
}
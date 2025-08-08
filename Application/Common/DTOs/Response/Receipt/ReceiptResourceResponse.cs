namespace Application.Common.DTOs.Response.Receipt;

public class ReceiptResourceResponse : BaseResponse
{
    public int ReceiptDocumentId { get; set; }
    public int ResourceId { get; set; }
    public int UnitOfMeasurementId { get; set; }
    public decimal Quantity { get; set; }
}
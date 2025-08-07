namespace Application.Common.DTOs.Request.Receipts;

public class GetReceiptAllRequest
{
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public List<string>? Numbers { get; set; }
    public List<int>? ResourceIds { get; set; }
    public List<int>? UnitIdsIds { get; set; }
}
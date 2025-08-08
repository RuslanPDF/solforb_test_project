namespace Application.Common.DTOs.Request.Resources;

public class ResourceItemRequest
{
    public int ResourceId { get; set; }
    public int UnitOfMeasurementId { get; set; }
    public decimal Quantity { get; set; }
    public int Id { get; set; }
}
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class ReceiptResource : Entity
{
    public int ReceiptDocumentId { get; set; }
    [JsonIgnore]
    public ReceiptDocument ReceiptDocument { get; set; }
    
    public int ResourceId { get; set; }
    public Resource Resource { get; set; }
    
    public int UnitOfMeasurementId { get; set; }
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
    
    public decimal Quantity { get; set; }
}
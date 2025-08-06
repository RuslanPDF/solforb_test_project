namespace Domain.Entities;

public class Resource : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool Status { get; set; }
    
    public ICollection<ReceiptResource> ReceiptResources { get; set; }
}
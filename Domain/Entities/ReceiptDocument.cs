namespace Domain.Entities;

public class ReceiptDocument : Entity
{
    public string Number { get; set; }
    public DateTime Date { get; set; }
    
    public ICollection<ReceiptResource> ReceiptResources { get; set; }
}
namespace portfolio.backend.Scripts.Data.Next_Tuto.Definitions;

public class InvoiceForm
{
    public string Status { get; init; } = string.Empty;

    public int Amount { get; init; }
    
    public Guid CustomerId { get; init; }
}
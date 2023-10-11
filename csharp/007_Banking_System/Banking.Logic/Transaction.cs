namespace Banking.Logic;

public class Transaction
{
    public string AccountNumber { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public decimal Amount { get; set; }
}

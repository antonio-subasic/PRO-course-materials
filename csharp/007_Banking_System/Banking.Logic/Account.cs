namespace Banking.Logic;

public abstract class Account
{
    public const string CHECKING = "c";
    public const string BUSINESS = "b";
    public const string SAVINGS = "s";
    public const string FIXED_DEPOSITE = "f";

    public string AccountNumber { get; set; } = "";
    public string AccountHolder { get; set; } = "";
    public decimal CurrentBalance { get; set; }
    public decimal InterestRate { get; set; }

    protected abstract bool IsAllowed(Transaction transaction);

    public virtual decimal CalculateMonthlyInterests() => CurrentBalance * InterestRate / 12;

    public bool TryExecute(Transaction transaction)
    {
        if (IsAllowed(transaction))
        {
            CurrentBalance += transaction.Amount;
            return true;
        }
        else { return false; }
    }
}

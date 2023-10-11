namespace Banking.Logic;

public class FixedDepositeAccount : Account
{

    private const decimal MIN_BALANCE = 0;
    private const decimal MAX_BALANCE = 10_000_000;

    public DateOnly OpeningDate { get; set; }
    public DateOnly FixedUntil { get; set; }

    protected override bool IsAllowed(Transaction transaction)
    {
        if (transaction.AccountNumber != AccountNumber) { return false; }
        else
        {
            if (transaction.Amount > 0)
            {
                if (DateOnly.FromDateTime(transaction.Timestamp) != OpeningDate) { return false; }
            }
            else
            {
                if (DateOnly.FromDateTime(transaction.Timestamp) < FixedUntil) { return false; }
            }

            var postTransactionBalance = CurrentBalance + transaction.Amount;
            return postTransactionBalance >= MIN_BALANCE && postTransactionBalance <= MAX_BALANCE;
        }
    }
}

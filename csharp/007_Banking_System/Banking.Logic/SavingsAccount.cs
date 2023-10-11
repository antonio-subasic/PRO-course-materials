namespace Banking.Logic;

public class SavingsAccount : Account
{
    private const decimal MIN_BALANCE = 0;
    private const decimal MAX_BALANCE = 100_000_000;

    protected override bool IsAllowed(Transaction transaction)
    {
        if (transaction.AccountNumber != AccountNumber) { return false; }
        else
        {
            var postTransactionBalance = CurrentBalance + transaction.Amount;
            return postTransactionBalance >= MIN_BALANCE && postTransactionBalance <= MAX_BALANCE;
        }
    }
}

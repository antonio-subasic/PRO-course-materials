namespace Banking.Logic;

public class CheckingAccount : Account
{
    private const decimal MIN_BALANCE = -10_000;
    private const decimal MAX_BALANCE = 10_000_000;
    private const decimal TRANSACTION_LIMIT = 10_000;

    protected override bool IsAllowed(Transaction transaction)
    {
        if (transaction.AccountNumber != AccountNumber || Math.Abs(transaction.Amount) > TRANSACTION_LIMIT)
        {
            return false;
        }
        else
        {
            var postTransactionBalance = CurrentBalance + transaction.Amount;
            return postTransactionBalance >= MIN_BALANCE && postTransactionBalance <= MAX_BALANCE;
        }
    }
}

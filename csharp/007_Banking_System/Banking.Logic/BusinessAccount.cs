namespace Banking.Logic;

public class BusinessAccount : BorrowingAccount
{
    private const decimal MIN_BALANCE = -1_000_000;
    private const decimal MAX_BALANCE = 100_000_000;
    private const decimal TRANSACTION_LIMIT = 100_000;

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

using Banking.Logic;

var account = HelperMethods.GetAccount(HelperMethods.GetStringInput($"Type of account ([{Account.CHECKING}]hecking, [{Account.BUSINESS}]usiness, [{Account.SAVINGS}]avings, [{Account.FIXED_DEPOSITE}]ixed deposite)"));
account.AccountNumber = HelperMethods.GetStringInput("Account number");
account.AccountHolder = HelperMethods.GetStringInput("Account holder");
account.CurrentBalance = HelperMethods.GetDecimalInput("Current balance");

if (account is FixedDepositeAccount fda)
{
    fda.OpeningDate = HelperMethods.GetDateOnlyInput("Opening date");
    fda.FixedUntil = HelperMethods.GetDateOnlyInput("Fixed until date");
}

var transaction = new Transaction
{
    AccountNumber = HelperMethods.GetStringInput("Transaction account number"),
    Description = HelperMethods.GetStringInput("Transaction description"),
    Timestamp = HelperMethods.GetDateTimeInput("Transaction timestamp"),
    Amount = HelperMethods.GetDecimalInput("Transaction amount")
};

Console.WriteLine();
Console.WriteLine(account.TryExecute(transaction)
    ? $"Transaction executed successfully. The new current balance is {account.CurrentBalance}€."
    : "Transaction not allowed."
);

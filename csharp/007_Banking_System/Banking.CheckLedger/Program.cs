using Banking.Logic;

var accountsData = HelperMethods.ParseFromCSVFile(args[0]);
var transactionsData = HelperMethods.ParseFromCSVFile(args[1]);

var accounts = accountsData.Select(accountData =>
    {
        var account = HelperMethods.GetAccount(accountData[0]);
        account.AccountNumber = accountData[1];
        account.AccountHolder = accountData[2];
        account.CurrentBalance = HelperMethods.ParseDecimal(accountData[3]);

        if (account is FixedDepositeAccount fda)
        {
            fda.OpeningDate = HelperMethods.ParseDateOnly(accountData[4]);
            fda.FixedUntil = HelperMethods.ParseDateOnly(accountData[5]);
        }

        return account;
    }).ToArray();

var transactions = transactionsData.Select(transactionData =>
    {
        return new Transaction
        {
            AccountNumber = transactionData[0],
            Description = transactionData[1],
            Timestamp = HelperMethods.ParseDateTime(transactionData[3]),
            Amount = HelperMethods.ParseDecimal(transactionData[2])
        };
    }).ToArray();

foreach (var transaction in transactions)
{
    var account = accounts.First(account => account.AccountNumber == transaction.AccountNumber);

    if (!account.TryExecute(transaction))
    {
        Console.WriteLine($"Transaction with description \"{transaction.Description}\" on \"{transaction.Timestamp}\" not allowed.");
    }
}

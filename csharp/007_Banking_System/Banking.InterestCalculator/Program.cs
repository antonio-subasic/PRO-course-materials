using Banking.Logic;

var account = HelperMethods.GetAccount(HelperMethods.GetStringInput($"Type of account ([{Account.CHECKING}]hecking, [{Account.BUSINESS}]usiness, [{Account.SAVINGS}]avings, [{Account.FIXED_DEPOSITE}]ixed deposite)"));
account.AccountNumber = HelperMethods.GetStringInput("Account number");
account.AccountHolder = HelperMethods.GetStringInput("Account holder");
account.CurrentBalance = HelperMethods.GetDecimalInput("Current balance");
account.InterestRate = HelperMethods.GetDecimalInput("Interest rate");

if (account is FixedDepositeAccount fda)
{
    fda.OpeningDate = HelperMethods.GetDateOnlyInput("Opening date");
    fda.FixedUntil = HelperMethods.GetDateOnlyInput("Fixed until date");
}

if (account is CheckingAccount or BusinessAccount && account.CurrentBalance < 0)
{
    var borrowingRate = HelperMethods.GetDecimalInput("Borrowing rate");

    if (account is CheckingAccount ca) { ca.BorrowingRate = borrowingRate; }
    else if (account is BusinessAccount ba) { ba.BorrowingRate = borrowingRate; }
}

Console.WriteLine($"\nThe monthly interest is {Math.Round(account.CalculateMonthlyInterests(), 2)}€.");

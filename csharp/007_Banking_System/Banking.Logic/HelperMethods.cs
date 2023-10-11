namespace Banking.Logic;

public static class HelperMethods
{
    public static Account GetAccount(string accountType)
    {
        return accountType switch
        {
            Account.CHECKING => new CheckingAccount(),
            Account.BUSINESS => new BusinessAccount(),
            Account.SAVINGS => new SavingsAccount(),
            Account.FIXED_DEPOSITE => new FixedDepositeAccount(),
            _ => throw new ArgumentException("Invalid account type")
        };
    }

    public static IEnumerable<string[]> ParseFromCSVFile(string filename, char delimiter = ';') => File.ReadAllLines(filename)[1..].Select(dataItem => dataItem.Split(delimiter));
    
    public static string GetStringInput(string message)
    {
        Console.Write($"{message}: ");
        return Console.ReadLine()!;
    }

    public static decimal ParseDecimal(string input) => decimal.TryParse(input, out var output) ? output : default;
    public static DateOnly ParseDateOnly(string input) => DateOnly.TryParse(input, out var output) ? output : default;
    public static DateTime ParseDateTime(string input) => DateTime.TryParse(input, out var output) ? output : default;

    public static decimal GetDecimalInput(string message) => ParseDecimal(GetStringInput(message));
    public static DateOnly GetDateOnlyInput(string message) => ParseDateOnly(GetStringInput(message));
    public static DateTime GetDateTimeInput(string message) => ParseDateTime(GetStringInput(message));
}

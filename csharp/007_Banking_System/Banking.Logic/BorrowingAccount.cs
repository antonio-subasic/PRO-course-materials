namespace Banking.Logic;

public abstract class BorrowingAccount : Account
{
    public decimal BorrowingRate { get; set; }

    public override decimal CalculateMonthlyInterests() => CurrentBalance < 0 ? CurrentBalance * BorrowingRate / 12 : base.CalculateMonthlyInterests();
}

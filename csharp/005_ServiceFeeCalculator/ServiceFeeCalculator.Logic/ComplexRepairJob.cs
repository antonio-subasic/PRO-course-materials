namespace ServiceFeeCalculator.Logic;

public class ComplexRepairJob : RepairJob
{
    private const decimal SUB_4_HOURS_RATE = 500m;
    private const decimal OVER_4_HOURS_RATE = 800m;

    public ComplexRepairJob(string description, string start, string end, string successful) : base(description, start, end, successful)
    { }

    public override decimal CalculateFee()
    {
        if (Successful) { return TotalHours <= 4 ? SUB_4_HOURS_RATE : OVER_4_HOURS_RATE; }
        else { return 0m; }
    }
}

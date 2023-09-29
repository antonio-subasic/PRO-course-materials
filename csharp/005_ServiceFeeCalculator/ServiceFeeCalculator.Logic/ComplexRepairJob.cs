namespace ServiceFeeCalculator.Logic;

public class ComplexRepairJob(string description, string start, string end, string successful)
    : RepairJob(description, start, end, successful)
{
    private const decimal SUB_4_HOURS_RATE = 500m;
    private const decimal OVER_4_HOURS_RATE = 800m;

    public override decimal CalculateFee()
    {
        if (Successful) { return TotalHours <= 4 ? SUB_4_HOURS_RATE : OVER_4_HOURS_RATE; }
        else { return 0m; }
    }
}

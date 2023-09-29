namespace ServiceFeeCalculator.Logic;

public class RegularRepairJob : RepairJob
{
    private const decimal TOTAL_HOUR_RATE = 80m;

    public RegularRepairJob(string description, string start, string end) : base(description, start, end)
    { }

    public override decimal CalculateFee() => TotalStartedHours * TOTAL_HOUR_RATE;
}

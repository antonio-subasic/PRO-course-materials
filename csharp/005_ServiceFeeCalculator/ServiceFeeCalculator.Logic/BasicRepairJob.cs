namespace ServiceFeeCalculator.Logic;

public class BasicRepairJob : RepairJob
{
    private const decimal QUATER_HOUR_RATE = 5m;

    public BasicRepairJob(string description, string start, string end, string numberOfMechanics) : base(description, start, end)
    {
        NumberOfMechanics = int.Parse(numberOfMechanics);
    }

    private int NumberOfMechanics { get; set; }

    public override decimal CalculateFee() => (int)Math.Ceiling(TotalHours * 60 / 15) * QUATER_HOUR_RATE * NumberOfMechanics;
}

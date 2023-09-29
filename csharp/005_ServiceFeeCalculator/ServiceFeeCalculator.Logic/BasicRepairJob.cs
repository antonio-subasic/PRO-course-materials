namespace ServiceFeeCalculator.Logic;

public class BasicRepairJob(string description, string start, string end, string numberOfMechanics)
    : TeamRepairJob(description, start, end, numberOfMechanics)
{
    private const decimal QUATER_HOUR_RATE = 5m;

    public override decimal CalculateFeeSingleMechanic => (int)Math.Ceiling(TotalHours * 60 / 15) * QUATER_HOUR_RATE;
}

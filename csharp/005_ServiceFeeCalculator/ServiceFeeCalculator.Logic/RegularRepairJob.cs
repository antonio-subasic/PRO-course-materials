namespace ServiceFeeCalculator.Logic;

public class RegularRepairJob(string description, string start, string end, string numberOfMechanics)
    : TeamRepairJob(description, start, end, numberOfMechanics)
{
    private const decimal TOTAL_HOUR_RATE = 80m;

    public override decimal CalculateFeeSingleMechanic => TotalStartedHours * TOTAL_HOUR_RATE;
}

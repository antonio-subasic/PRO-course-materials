namespace ServiceFeeCalculator.Logic;

public abstract class TeamRepairJob(string description, string start, string end, string numberOfMechanics)
    : RepairJob(description, start, end)
{
    protected int NumberOfMechanics { get; set; } = int.Parse(numberOfMechanics);

    public abstract decimal CalculateFeeSingleMechanic { get; }

    public override decimal CalculateFee() => CalculateFeeSingleMechanic * NumberOfMechanics;
}

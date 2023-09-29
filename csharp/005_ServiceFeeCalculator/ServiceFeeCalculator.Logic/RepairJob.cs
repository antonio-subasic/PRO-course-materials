namespace ServiceFeeCalculator.Logic;

public abstract class RepairJob(string description, string start, string end, string successful = "true")
{
    public string Description { get; set; } = description;
    public DateTime Start { get; set; } = DateTime.Parse(start);
    public DateTime End { get; set; } = DateTime.Parse(end);
    public bool Successful { get; set; } = successful.ToLower() == "true";
    protected double TotalHours => (End - Start).TotalHours;
    protected int TotalStartedHours => (int)Math.Ceiling(TotalHours);

    public abstract decimal CalculateFee();
}

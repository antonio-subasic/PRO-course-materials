using ServiceFeeCalculator.Logic;

const string BASIC = "b";
const string REGULAR = "r";
const string COMPLEX = "c";

Console.Write("Enter the repair job type ([b]asic, [r]egular, [c]omplex): ");
var repairJobType = Console.ReadLine()!;

Console.Write("Enter the description: ");
var description = Console.ReadLine()!;

Console.Write("Enter the start time (iso 8601 format): ");
var start = Console.ReadLine()!;

Console.Write("Enter the end time (iso 8601 format): ");
var end = Console.ReadLine()!;


RepairJob repairJob;
switch (repairJobType.ToLower())
{
    case BASIC:
        Console.Write("Enter the number of mechanics: ");
        var numberOfMechanics = Console.ReadLine()!;
        repairJob = new BasicRepairJob(description, start, end, numberOfMechanics);
        break;
    case REGULAR:
        repairJob = new RegularRepairJob(description, start, end);
        break;
    case COMPLEX:
        Console.Write("Enter wether the input was successful (true/false): ");
        var successful = Console.ReadLine()!;
        repairJob = new ComplexRepairJob(description, start, end, successful);
        break;
    default:
        throw new Exception();
}

Console.WriteLine($"\nYour calculated fee: {repairJob.CalculateFee()}€");

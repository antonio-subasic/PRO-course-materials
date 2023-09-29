using ServiceFeeCalculator.Logic;

const string BASIC = "b";
const string REGULAR = "r";
const string COMPLEX = "c";

Console.Write($"Enter the repair job type ([{BASIC}]asic, [{REGULAR}]egular, [{COMPLEX}]omplex): ");
var repairJobType = Console.ReadLine()!.ToLower();

if (!(repairJobType is BASIC or REGULAR or COMPLEX)) { Console.WriteLine("You must enter a valid job type"); }
else
{
    Console.Write("Enter the description: ");
    var description = Console.ReadLine()!;

    Console.Write("Enter the start time (iso 8601 format): ");
    var start = Console.ReadLine()!;

    Console.Write("Enter the end time (iso 8601 format): ");
    var end = Console.ReadLine()!;

    RepairJob repairJob;
    switch (repairJobType)
    {
        case BASIC:
        case REGULAR:
            {
                Console.Write("Enter the number of mechanics: ");
                var numberOfMechanics = Console.ReadLine()!;

                repairJob = repairJobType == BASIC
                    ? new BasicRepairJob(description, start, end, numberOfMechanics)
                    : new RegularRepairJob(description, start, end, numberOfMechanics);
                break;
            }

        case COMPLEX:
            {
                Console.Write("Enter wether the input was successful (true/false): ");
                var successful = Console.ReadLine()!;

                repairJob = new ComplexRepairJob(description, start, end, successful);
                break;
            }

        default: return;
    }

    Console.WriteLine($"\nYour calculated fee: {repairJob.CalculateFee()}€");
}

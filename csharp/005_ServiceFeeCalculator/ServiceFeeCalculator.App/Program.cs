using ServiceFeeCalculator.Logic;

const string BASIC = "b";
const string REGULAR = "r";
const string COMPLEX = "c";

Console.Write("Enter the number of jobs: ");
var numberOfJobs = int.Parse(Console.ReadLine()!);

var repairJobs = new RepairJob[numberOfJobs];
for (var i = 0; i < numberOfJobs; i++)
{
    Console.Write($"Enter the repair job type ([{BASIC}]asic, [{REGULAR}]egular, [{COMPLEX}]omplex): ");
    var repairJobType = Console.ReadLine()!.ToLower();

    Console.Write("Enter the description: ");
    var description = Console.ReadLine()!;

    Console.Write("Enter the start time (iso 8601 format): ");
    var start = Console.ReadLine()!;

    Console.Write("Enter the end time (iso 8601 format): ");
    var end = Console.ReadLine()!;

    switch (repairJobType)
    {
        case BASIC:
        case REGULAR:
            {
                Console.Write("Enter the number of mechanics: ");
                var numberOfMechanics = Console.ReadLine()!;

                repairJobs[i] = repairJobType == BASIC
                    ? new BasicRepairJob(description, start, end, numberOfMechanics)
                    : new RegularRepairJob(description, start, end, numberOfMechanics);
                break;
            }

        case COMPLEX:
            {
                Console.Write("Enter wether the input was successful (true/false): ");
                var successful = Console.ReadLine()!;

                repairJobs[i] = new ComplexRepairJob(description, start, end, successful);
                break;
            }

        default: return;
    }
}

Console.WriteLine();
var totalFee = 0m;
for (var i = 0; i < repairJobs.Length; i++)
{
    var fee = repairJobs[i].CalculateFee();

    {
        Console.Write($"{i + 1}. job fee: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{fee}€");
        Console.ResetColor();
    }
    totalFee += fee;
}

{
    Console.Write($"\nYour total fee: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{totalFee}€");
    Console.ResetColor();
}

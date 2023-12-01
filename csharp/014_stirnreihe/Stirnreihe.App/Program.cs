using Stirnreihe.Data;

const string ADD = "1";
const string ADD_SORTED = "1b";
const string PRINT = "2";
const string REMOVE_AT = "3";
const string CLEAR = "4";
const string SORT = "5";
const string EXIT = "6";

Console.WriteLine($"""
Welcome to the Stirnreihe World Record App! What do you want to do?
{ADD}) Add a person to the line
{ADD_SORTED}) Add a person to the line (sorted)
{PRINT}) Print the line
{REMOVE_AT}) Removes a person at a given index
{CLEAR}) Clear the line
{SORT}) Sort the line
{EXIT}) Exit
""");

var lineOfPeople = new LineOfPeople();
string choice;

do
{
    Console.Write("\nYour choice: ");
    choice = Console.ReadLine()!;

    Console.WriteLine();

    switch (choice)
    {
        case ADD:
            lineOfPeople.AddToFront(GetPersonFromUser());
            break;

        case ADD_SORTED:
            Console.WriteLine(lineOfPeople.AddSorted(GetPersonFromUser()));
            break;

        case PRINT:
            var output = lineOfPeople.ToString().TrimEnd('\n');
            Console.WriteLine(output == "" ? "The line is empty" : output);
            break;

        case REMOVE_AT:
            {
                Console.Write("Enter the index of the person you want to remove: ");
                var index = int.Parse(Console.ReadLine()!);
                var person = lineOfPeople.RemovePersonAt(index);
                Console.WriteLine(person is null ? "Removed noone" : $"Removed person: {person}");
                break;
            }

        case CLEAR:
            lineOfPeople.Clear();
            Console.WriteLine("The line has been cleared.");
            break;

        case SORT:
            lineOfPeople.Sort();
            break;
    }
} while (choice != EXIT);

static Person GetPersonFromUser()
{
    Console.Write("First name: ");
    var firstName = Console.ReadLine()!;

    Console.Write("Last name: ");
    var lastName = Console.ReadLine()!;

    Console.Write("Height in cm: ");
    var height = int.Parse(Console.ReadLine()!);

    return new(firstName, lastName, height);
}

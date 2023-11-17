using RestaurantQueue.Logic;

#region Choice Options
const int ADD = 1;
const int SEAT = 2;
const int DISPLAY = 3;
const int SAVE = 4;
const int LOAD = 5;
const int REMOVE = 6;
#endregion

#region Choice Options Output
Console.WriteLine($"""
What do you want to do?
{ADD}) Add a customer to the queue
{SEAT}) Seat the next customer
{DISPLAY}) Display the queue
{SAVE}) Save the queue to queue.json
{LOAD}) Load the queue from queue.json
{REMOVE}) Remove customer from the queue
""");
#endregion

var restaurantQueue = new RestaurantQueue.Logic.RestaurantQueue();

do
{
    Console.Write("\nYour choice: ");
    var choice = int.Parse(Console.ReadLine()!);

    switch (choice)
    {
        case ADD:
            {
                Console.Write("Enter customer name: ");
                var name = Console.ReadLine()!;

                Console.Write("Enter customer phone number: ");
                var phoneNumber = Console.ReadLine()!;

                restaurantQueue.Add(new CustomerInQueue(name, phoneNumber));
                break;
            }

        case SEAT:
            var customer = restaurantQueue.Remove();
            if (customer is not null) { Console.WriteLine($"Seating {customer}"); }
            break;

        case DISPLAY:
            Console.WriteLine(restaurantQueue);
            break;

        case SAVE:
            Console.WriteLine(restaurantQueue.Save("queue.json"));
            return;

        case LOAD:
            var output = restaurantQueue.TryLoad("queue.json");
            if (output is not null) { Console.WriteLine(output); }
            break;

        case REMOVE:
            {
                Console.Write("Enter customer name: ");
                var name = Console.ReadLine()!;

                restaurantQueue.RemoveByName(name);
                break;
            }
    }
} while (!restaurantQueue.IsEmpty);

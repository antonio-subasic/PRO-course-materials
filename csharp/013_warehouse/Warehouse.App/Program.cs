using Warehouse.Logic;

var warehouse = new Warehouse.Logic.Warehouse();
var operations = File.ReadAllLines(args[0]).Select(line => line.Split(' ')).ToArray();

for (var i = 0; i < operations.Length; i++)
{
    var operation = (action: operations[i][0], item: new Box(operations[i][1]));

    Console.WriteLine($"{operation.action} {operation.item}");

    switch (operation.action.ToLower())
    {
        case "incoming":
            warehouse.Push(operation.item);
            break;

        case "shipping":
            warehouse.PopBox(operation.item);
            break;
    }

    Console.WriteLine(warehouse);
    Console.WriteLine($"{(i == operations.Length - 1 ? "Total b" : "B")}ox movements: {warehouse.Movements}\n");
}

using Warehouse.Logic;

var mainStack = new ClothesStack();
var tempStack = new ClothesStack();

var operations = File.ReadAllLines(args[0]).Select(line => line.Split(' ')).ToArray();

foreach (var operation in operations)
{
    Console.WriteLine(string.Join(' ', operation));

    var item = operation[1];

    switch (operation[0].ToLower())
    {
        case "incoming":
            mainStack.Push(new(item));
            break;

        case "shipping":
            for (var itemToShip = mainStack.Pop(); itemToShip is not null && itemToShip.Name != item; itemToShip = mainStack.Pop())
            {
                tempStack.Push(itemToShip);
            }

            for (var tempItem = tempStack.Pop(); tempItem is not null; tempItem = tempStack.Pop())
            {
                mainStack.Push(tempItem);
            }

            break;
    }

    Console.WriteLine(mainStack);
    Console.WriteLine($"Box movements: {mainStack.Movements}\n");
}

Console.WriteLine($"Total box movements: {mainStack.Movements}");

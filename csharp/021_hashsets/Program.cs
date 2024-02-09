HashSet<int> numbers = [1, 2, 3, 4, 5, 5];

foreach (int number in numbers)
{
    Console.WriteLine(number);
}

if (numbers.Contains(3))
{
    Console.WriteLine("yes");
}

HashSet<int> otherNumbers = [1, 2, 3, 4, 5];

if (numbers.SetEquals(otherNumbers))
{
    Console.WriteLine("equal");
}

// Console.WriteLine("8".GetHashCode());

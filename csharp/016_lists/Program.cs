// <int> is the TYPE PARAMETER
// List is a GENERIC CLASS
List<int> numbers = [1, 2, 3];
List<string> names = ["tim", "tom"];
List<Point> points = [new(1, 2), new(3, 4)];
List<List<int>> listOfLists = [];


numbers.Add(4);
foreach (var number in numbers) { Console.WriteLine(number); }

Console.WriteLine(names[0]);

numbers.Insert(0, -1);
numbers[0] = 0;

numbers.RemoveAt(0);

numbers = [1, 2, 3];
var numbers2 = numbers;
numbers2[0] = 5;
// What is numbers[0]? => 5

var numbers3 = numbers.ToList();
numbers3[0] = 10;
// What is numbers[0]? => 5

// LINQ = Language Integrated Query
var sum = numbers.Sum();
var average = numbers.Average();
var max = numbers.Max();
var min = numbers.Min();
var first = numbers.First();
var last = numbers.Last();
var count = numbers.Count;
// ...


record Point(int X, int Y);

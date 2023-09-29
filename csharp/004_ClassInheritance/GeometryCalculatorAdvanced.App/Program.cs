using GeometryCalculator;

Shape myShape = new Circle(10); // "Circle(10)" can easily be changed to "Rectangle(10, 10)" without errors
// Shape myShape = new Rectangle(10, 10); // works just as well without any errors
Console.WriteLine(myShape);
// Environment.Exit(0);

Console.Write("Enter the type of the geometric figure ([r]ectangle, [c]ircle, [t]riangle): ");
var figureType = Console.ReadLine()!;

Shape shape;
switch (figureType)
{
    case "r":
        {
            Console.Write("Enter the width of the rectangle: ");
            var width = double.Parse(Console.ReadLine()!);
            Console.Write("Enter the height of the rectangle: ");
            var height = double.Parse(Console.ReadLine()!);
            shape = new Rectangle(width, height);
            break;
        }
    case "c":
        {
            Console.Write("Enter the radius of the circle: ");
            var radius = double.Parse(Console.ReadLine()!);
            shape = new Circle(radius);
            break;
        }
    case "t":
        {
            Console.Write("Enter the base of the triangle: ");
            var baseLength = double.Parse(Console.ReadLine()!);
            Console.Write("Enter the height of the triangle: ");
            var height = double.Parse(Console.ReadLine()!);
            shape = new Triangle(baseLength, height);
            break;
        }
    case "e":
        {
            Console.Write("Enter the longest radius of the ellipse: ");
            var longestRadius = double.Parse(Console.ReadLine()!);
            Console.Write("Enter the shortest radius of the ellipse: ");
            var shortestRadius = double.Parse(Console.ReadLine()!);
            shape = new Ellipse(longestRadius, shortestRadius);
            break;
        }
    default:
        Console.WriteLine("Invalid figure type.");
        return;
}

Console.Write("Enter the factor: ");
var factor = double.Parse(Console.ReadLine()!);

Console.WriteLine($"The original area of {shape} is {shape.Area}");
shape.Scale(factor);
Console.WriteLine($"The new area of {shape} is {Math.Round(shape.Area, 3)}");

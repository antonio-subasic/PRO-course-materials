using GeometryCalculator;

public class Program
{
    const string RECTANGLE = "rectangle";
    const string CIRCLE = "circle";
    const string TRIANGLE = "triangle";

    static void Main()
    {
        Console.Write($"Enter the type of the geometric figure ({RECTANGLE}, {CIRCLE}, {TRIANGLE}): ");
        var geometricFigure = Console.ReadLine()!.ToLower();


        (double width, double height) rectangle = (0, 0);
        double radius = 0;
        (double baseLength, double height) triangle = (0, 0);

        switch (geometricFigure)
        {
            case RECTANGLE:
                rectangle = GetTwoInputs("width", "height");
                break;
            case CIRCLE:
                Console.Write("Enter the radius: ");
                radius = double.Parse(Console.ReadLine()!);
                break;
            case TRIANGLE:
                triangle = GetTwoInputs("baseLength", "height");
                break;
        }


        Console.Write("Enter the factor: ");
        var factor = double.Parse(Console.ReadLine()!);


        PrintData(geometricFigure, rectangle, radius, triangle, true);


        switch (geometricFigure)
        {
            case RECTANGLE:
                rectangle = RectangleMath.CalculateScaledDimensions(rectangle.width, rectangle.height, factor);
                break;
            case CIRCLE:
                radius = CircleMath.CalculateScaledDimensions(radius, factor);
                break;
            case TRIANGLE:
                triangle = TriangleMath.CalculateScaledDimensions(triangle.baseLength, triangle.height, factor);
                break;
        }


        PrintData(geometricFigure, rectangle, radius, triangle, false);
    }

    static (double, double) GetTwoInputs(string figureName1, string figureName2)
    {
        Console.Write($"Enter the {figureName1} and {figureName2} ({figureName1}, {figureName2}): ");
        var input = Console.ReadLine()!.Split(',');

        return (
            double.Parse(input[0]),
            double.Parse(input[1])
        );
    }

    static void PrintData(string geometricFigure, (double width, double height) rectangle, double radius, (double baseLength, double height) triangle, bool old)
    {
        var area = geometricFigure switch
        {
            RECTANGLE => RectangleMath.CalculateArea(rectangle.width, rectangle.height),
            CIRCLE => CircleMath.CalculateArea(radius),
            _ => TriangleMath.CalculateArea(triangle.baseLength, triangle.height)
        };

        Console.Write($"\n{(old ? "OLD" : "NEW")}:\n\tarea: {Math.Round(area, 3)}\n\t");
        Console.WriteLine(geometricFigure switch
        {
            RECTANGLE => $"width: {rectangle.width}\n\theight: {rectangle.height}",
            CIRCLE => $"radius: {radius}",
            _ => $"base length: {triangle.baseLength}\n\theight: {triangle.height}"
        });
    }
}

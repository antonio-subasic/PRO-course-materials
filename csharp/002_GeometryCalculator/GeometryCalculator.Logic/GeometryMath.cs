namespace GeometryCalculator;

public static class RectangleMath
{
    public static double CalculateArea(double width, double height) => width * height;
    public static (double width, double height) CalculateScaledDimensions(double width, double height, double factor)
    {
        var rootOfScalingFactor = Math.Sqrt(factor);

        return (
            rootOfScalingFactor * width,
            rootOfScalingFactor * height
        );
    }
}

public static class CircleMath
{
    public static double CalculateArea(double radius) => radius * radius * Math.PI;
    public static double CalculateScaledDimensions(double radius, double factor) => Math.Sqrt(factor) * radius;
}

public static class TriangleMath
{
    public static double CalculateArea(double baseLength, double height) => baseLength * height / 2;
    public static (double baseLength, double height) CalculateScaledDimensions(double baseLength, double height, double factor)
    {
        var rootOfScalingFactor = Math.Sqrt(factor);

        return (
            rootOfScalingFactor * baseLength,
            rootOfScalingFactor * height
        );
    }
}

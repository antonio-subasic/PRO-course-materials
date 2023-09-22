namespace GeometryCalculator;

// new constructors in dotnet 8
public class Triangle(double baseLength, double height)
{
    public double BaseLength { get; set; } = baseLength;
    public double Height { get; set; } = height;

    public double Area => BaseLength * Height / 2;

    public void Scale(double factor)
    {
        var scaledFactor = Math.Sqrt(factor);

        BaseLength *= scaledFactor;
        Height *= scaledFactor;
    }
}

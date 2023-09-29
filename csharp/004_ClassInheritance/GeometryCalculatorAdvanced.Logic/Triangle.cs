namespace GeometryCalculator;

// new constructors in dotnet 8
public class Triangle(double baseLength, double height) : Shape
{
    public double BaseLength { get; set; } = baseLength;
    public double Height { get; set; } = height;

    public override double Area => BaseLength * Height / 2;

    public override void Scale(double factor)
    {
        BaseLength *= CalculateScaledFactor(factor);
        Height *= CalculateScaledFactor(factor);
    }

    public override string ToString()
    {
        return $"Triangle (baseLength={BaseLength}, height={Height})";
    }
}

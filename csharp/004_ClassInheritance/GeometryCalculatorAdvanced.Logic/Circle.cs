namespace GeometryCalculator;

public class Circle : Shape
{
    // Constructor
    public Circle(double radius)
    {
        Radius = radius;
    }

    // Property
    public double Radius { get; /*private*/ set; } // default value: = 1d;

    // Calculated Property
    public override double Area => Math.PI * Radius * Radius;

    public override void Scale(double factor)
    {
        Radius *= CalculateScaledFactor(factor);
    }

    public override string ToString()
    {
        return $"Circle (radius={Radius})";
    }
}

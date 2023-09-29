namespace GeometryCalculator;

public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area => Width * Height;

    public override void Scale(double factor)
    {
        Width *= CalculateScaledFactor(factor);
        Height *= CalculateScaledFactor(factor);
    }

    // overrides the ToString() method from the ultimate "Object" base class
    public override string ToString()
    {
        return $"Rectangle (width={Width}, height={Height})";
    }
}

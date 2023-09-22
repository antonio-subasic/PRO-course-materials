namespace GeometryCalculator;

public class Rectangle
{
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; set; }
    public double Height { get; set; }

    public double Area => Width * Height;

    public void Scale(double factor)
    {
        var scaledFactor = Math.Sqrt(factor);

        Width *= scaledFactor;
        Height *= scaledFactor;
    }
}

namespace GeometryCalculator;

public class Ellipse(double longestRadius, double shortestRadius)
{
    public double LongestRadius { get; set; } = longestRadius;
    public double ShortestRadius { get; set; } = shortestRadius;

    public double Area => Math.PI * LongestRadius * ShortestRadius;

    public void Scale(double factor)
    {
        // moving Math.Sqrt() to extra variable (like in Rectangle.cs) not necessary -> modern compilers detect that duplication and perform it only once

        LongestRadius *= Math.Sqrt(factor);
        ShortestRadius *= Math.Sqrt(factor);
    }
}

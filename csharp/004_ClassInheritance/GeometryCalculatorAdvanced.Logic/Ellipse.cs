namespace GeometryCalculator;

public class Ellipse(double longestRadius, double shortestRadius) : Shape
{
    public double LongestRadius { get; set; } = longestRadius;
    public double ShortestRadius { get; set; } = shortestRadius;

    public override double Area => Math.PI * LongestRadius * ShortestRadius;

    public override void Scale(double factor)
    {
        // moving the calculation of scaled factor to extra variable not necessary -> modern compilers detect that duplication and perform it only once

        LongestRadius *= CalculateScaledFactor(factor);
        ShortestRadius *= CalculateScaledFactor(factor);
    }

    public override string ToString()
    {
        return $"Ellipse (longestRadius={LongestRadius}, shortestRadius={ShortestRadius})";
    }
}

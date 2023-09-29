// BASE CLASS for Circle, Rectangle, etc.

public abstract class Shape // only for inheritance, cannot be used direclty
{
    public abstract double Area { get; } // contracts that all descendants must implemenet a property "Area"

    public abstract void Scale(double factor); // contracts that all descendants must implement a method "Scale"

    // helper method provided by base class -> protected = only for decendent classes
    protected double CalculateScaledFactor(double factor) => Math.Sqrt(factor);
}

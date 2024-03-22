public class Rectangle(Coordinate topLeft, Coordinate bottomRight, Stroke stroke)
    : Polygon([
        topLeft,
        new(bottomRight.X, topLeft.Y),
        bottomRight,
        new(topLeft.X, bottomRight.Y)
    ], stroke)
{ }
public class Point(Coordinate position, Stroke stroke) : Shape(stroke)
{
    public Point(int x, int y, Stroke stroke) : this(new Coordinate(x, y), stroke) { }

    public override void Draw()
    {
        Console.SetCursorPosition(position.X, position.Y);
        Console.ForegroundColor = Stroke.ForegroundColor;
        Console.BackgroundColor = Stroke.BackgroundColor;
        Console.Write(Stroke.Symbol);
    }
}

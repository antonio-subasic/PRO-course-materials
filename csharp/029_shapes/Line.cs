public class Line(Coordinate start, Coordinate end, Stroke stroke) : Shape(stroke)
{
    public override void Draw()
    {
        Console.SetCursorPosition(start.X, start.Y);
        Console.BackgroundColor = Stroke.BackgroundColor;
        Console.ForegroundColor = Stroke.ForegroundColor;
        Console.Write(Stroke.Symbol);

        int dx = end.X - start.X;
        int dy = end.Y - start.Y;
        int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
        float xInc = dx / (float)steps;
        float yInc = dy / (float)steps;
        float x = start.X;
        float y = start.Y;

        for (int i = 0; i < steps; i++)
        {
            x += xInc;
            y += yInc;
            Console.SetCursorPosition((int)Math.Round(x), (int)Math.Round(y));
            Console.BackgroundColor = Stroke.BackgroundColor;
            Console.ForegroundColor = Stroke.ForegroundColor;
            Console.Write(Stroke.Symbol);
        }

        Console.SetCursorPosition(end.X, end.Y);
        Console.BackgroundColor = Stroke.BackgroundColor;
        Console.ForegroundColor = Stroke.ForegroundColor;
        Console.Write(Stroke.Symbol);

    }
}

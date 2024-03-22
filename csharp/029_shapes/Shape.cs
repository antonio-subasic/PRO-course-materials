public abstract class Shape(Stroke stroke)
{
    public Stroke Stroke { get; set; } = stroke;
    public abstract void Draw();
}

public record struct Stroke(ConsoleColor ForegroundColor, ConsoleColor BackgroundColor, char Symbol);

public record struct Coordinate(int X, int Y);

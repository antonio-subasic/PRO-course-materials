public class Polygon(Coordinate[] points, Stroke stroke) : Shape(stroke)
{
    public override void Draw()
    {
        for (int i = 0; i < points.Length; i++)
        {
            var start = points[i];
            var end = points[(i + 1) % points.Length];
            new Line(start, end, Stroke).Draw();
        }
    }
}
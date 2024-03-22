// Shape
// - Draw-Method
// - "Stroke" (color, symbol)

// Point - coordinate: (x / y)
// Line - coordinates: 2x (x / y)
// Polaygon - multiple lines
// Triangle - three lines (special polygon)
// Rectangle - four lines (special polygon)
// Square - four lines (special rectangle)
// Ellipse - some lines ("tesselation" of lines) (special polygon)
// Circle - special ellipse

var stroke = new Stroke(ConsoleColor.White, ConsoleColor.Black, ' ');

List<Shape> shapes = [
    // new Point(10, 10, stroke),
    // new Point(new(15, 15), stroke),
    // new Point(25, 10, stroke),
    new Line(new(2, 2), new(10, 3), stroke),
    new Line(new(2, 2), new(15, 18), stroke),
];

Console.CursorVisible = false;
Console.Clear();

foreach (var shape in shapes)
{
    shape.Draw();
}

Console.ReadKey();

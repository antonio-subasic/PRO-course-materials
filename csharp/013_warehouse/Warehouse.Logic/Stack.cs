using System.Text;

namespace Warehouse.Logic;

public class ClothesStack
{
    public Box? Top { get; private set; }
    public uint Movements { get; set; }

    public void Push(Box box)
    {
        box.Previous = Top;
        Top = box;

        Movements++;
    }

    public Box? Pop()
    {
        var current = Top;
        Top = Top?.Previous;

        Movements++;
        return current;
    }

    public override string? ToString()
    {
        var stringBuilder = new StringBuilder();

        for (var item = Top; item is not null; item = item.Previous)
        {
            stringBuilder.Append(item.ToString());
            if (item.Previous is not null) { stringBuilder.Append(", "); }
        }

        return stringBuilder.ToString().Trim('\n');
    }
}

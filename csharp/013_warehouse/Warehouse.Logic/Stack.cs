using System.Text;

namespace Warehouse.Logic;

public class ClothesStack
{
    public Box? Top { get; private set; }
    public int Size { get; private set; }

    public void Push(Box box)
    {
        box.Previous = Top;
        Top = box;

        Size++;
    }

    public Box? Pop()
    {
        var current = Top;
        Top = Top?.Previous;

        Size -= current is null ? 0 : 1;
        return current;
    }

    public uint? TryGetDepth(Box box)
    {
        uint count = 0;

        for (
            var item = Top;
            item is not null;
            item = item?.Previous, count++
        )
        {
            if (item.Name == box.Name) { return count; }
        }

        return null;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        for (var item = Top; item is not null; item = item.Previous)
        {
            stringBuilder.Append(item.ToString());
            if (item.Previous is not null) { stringBuilder.Append(", "); }
        }

        return stringBuilder.ToString();
    }
}

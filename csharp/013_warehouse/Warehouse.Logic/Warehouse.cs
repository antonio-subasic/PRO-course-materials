using System.Text;

namespace Warehouse.Logic;

public class Warehouse
{
    public ClothesStack[] Stacks { get; } = new ClothesStack[5];
    public uint Movements { get; private set; }

    public Warehouse()
    {
        for (var i = 0; i < Stacks.Length; i++)
        {
            Stacks[i] = new();
        }
    }

    public void Push(Box box)
    {
        GetLowestStack().Push(box);
        Movements++;
    }

    public Box? PopBox(Box box)
    {
        var nearestToTop = GetStackWithBoxNearestToTop(box);

        var itemToRemove = nearestToTop.stack.Pop();
        Movements++;

        for (
            ;
            itemToRemove is not null && itemToRemove.Name != box.Name;
            itemToRemove = nearestToTop.stack.Pop(), Movements++
        )
        {
            GetLowestStack(nearestToTop.index).Push(itemToRemove);
        }

        return itemToRemove;
    }

    private ClothesStack GetLowestStack(int? excludedStack = null)
    {
        var stacksWithExcluded = Stacks.Where((source, index) => index != excludedStack);
        return stacksWithExcluded.OrderBy(stack => stack?.Size ?? 0).ElementAt(0);
    }

    private (ClothesStack stack, int index) GetStackWithBoxNearestToTop(Box box)
    {
        var orderedStacks = Stacks
            .Select((stack, index) => (stack, index, depth: stack.TryGetDepth(box)))
            .Where(stack => stack.depth is not null)
            .OrderBy(stack => stack.depth);

        var stack = orderedStacks.ElementAt(0);
        return (stack.stack, stack.index);
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        for (var i = 0; i < Stacks.Length; i++)
        {
            stringBuilder.AppendLine($"Stack {i}: {Stacks[i]}");
        }

        return stringBuilder.ToString();
    }
}

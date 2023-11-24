namespace Warehouse.Logic;

public class Box(string? name = null)
{
    public string? Name { get; } = name;
    public Box? Previous { get; set; }

    public override string? ToString() => Name;
}

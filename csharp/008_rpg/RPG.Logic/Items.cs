namespace RPG.Logic;

public abstract class Item(string name, double baseValue)
{
    public string Name { get; } = name;
    public double BaseValue { get; set; } = baseValue;
    public abstract double CalculatedValue { get; }

    public override string ToString() => $"{Name} ({GetType().ToString().Split('.')[^1]})";
}

public class Weapon(string name, double baseValue) : Item(name, baseValue)
{
    public override double CalculatedValue => BaseValue * Random.Shared.Next(50, 101) / 100d;
}

public class Spell(string name, double baseValue) : Item(name, baseValue)
{
    public override double CalculatedValue => Random.Shared.Next(0, 101) <= 80 ? BaseValue : 0;
}

public class Shield(string name, double baseValue) : Item(name, baseValue)
{
    public override double CalculatedValue => BaseValue * Random.Shared.Next(75, 101) / 100d;
}

public class Armor(string name, double baseValue) : Item(name, baseValue)
{
    public override double CalculatedValue => BaseValue;
}

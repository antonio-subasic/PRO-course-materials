namespace RPG.Logic;

public abstract class Character(string name, double health)
{
    public string Name { get; } = name;
    public double Health { get; private set; } = health;
    protected virtual List<Item> AttackItems { get; } = new();
    protected virtual List<Item> DefenseItems { get; } = new();

    public Item AttackItem => AttackItems[Random.Shared.Next(AttackItems.Count)];
    public Item? DefenseItem => DefenseItems.Count == 0 ? null : DefenseItems[Random.Shared.Next(DefenseItems.Count)];

    public override string ToString() => $"{Name} ({GetType().ToString().Split('.')[^1]})\n\tHealth: {(Health > 0 ? Health : 0)}\n\tAttack: {string.Join(", ", AttackItems)}\n\tDefense: {string.Join(", ", DefenseItems)}";

    public (string weapon, string damage) Attack(Character character)
    {
        var damageDealt = AttackItem.CalculatedValue - (character.DefenseItem?.CalculatedValue ?? 0);

        if (damageDealt > 0)
        {
            if (character.DefenseItem is not null) { character.DefenseItems.Remove(character.DefenseItem!); }
            character.Health -= damageDealt;
        }
        else if (character.DefenseItem is not null) { character.DefenseItem.BaseValue *= 0.5; }

        return (AttackItem?.ToString() ?? "no attack item", (damageDealt > 0 ? damageDealt : 0).ToString());
    }
}

public class Warrior(string name, double health, Item Attack, Item Defense) : Character(name, health)
{
    protected override List<Item> AttackItems { get; } = new() { Attack };
    protected override List<Item> DefenseItems { get; } = new() { Defense };
}

public class Mage(string name, double health, Item Attack) : Character(name, health)
{
    protected override List<Item> AttackItems { get; } = new() { Attack };
}

public class Rogue(string name, double health, List<Item> Attack) : Character(name, health)
{
    protected override List<Item> AttackItems { get; } = Attack;
}

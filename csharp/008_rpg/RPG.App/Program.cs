using RPG.Logic;

#region Role/Item/Character assignments
var weapons = new Weapon[]
{
    new("Stormbringer Blade", 30),
    new("Ravenclaw Blade", 28),
    new("Night's Fang", 9),
    new("Silent Whisper", 11),
    new("Tempest Blade", 32),
    new("Starshard Lance", 28),
    new("Whispering Dagger", 10),
    new("Baselard", 12)
};

var shields = new Shield[]
{
    new("Guardian of Dawn", 14),
    new("Bulwark of the Ancients", 15),
    new("Guardian of the Forest", 16),
    new("Bulwark of the Elements", 17)
};

var spells = new Spell[]
{
    new("Starflare", 50),
    new("Starfire", 45),
    new("Starstorm", 40),
    new("Starlight", 35)
};

var armors = new Armor[]
{
    new("Eclipse Ward", 20),
    new("Aetherial Barrier", 22),
    new("Eclipse Guard", 24),
    new("Aetherial Guard", 26)
};

Character character1 = Random.Shared.Next(3) switch
{
    0 => new Warrior("Character 1", 100, weapons[Random.Shared.Next(weapons.Length)], shields[Random.Shared.Next(shields.Length)]),
    1 => new Mage("Character 1", 100, spells[Random.Shared.Next(spells.Length)]),
    2 => new Rogue("Character 1", 100, new() { weapons[Random.Shared.Next(weapons.Length)], weapons[Random.Shared.Next(weapons.Length)] }),
    _ => throw new Exception("This should never happen.")
};

Character character2 = Random.Shared.Next(3) switch
{
    0 => new Warrior("Character 2", 100, weapons[Random.Shared.Next(weapons.Length)], shields[Random.Shared.Next(shields.Length)]),
    1 => new Mage("Character 2", 100, spells[Random.Shared.Next(spells.Length)]),
    2 => new Rogue("Character 2", 100, new() { weapons[Random.Shared.Next(weapons.Length)], weapons[Random.Shared.Next(weapons.Length)] }),
    _ => throw new Exception("This should never happen.")
};
#endregion

var currentTurn = Random.Shared.Next() % 2;

Console.Clear();
Console.WriteLine($"{character1}\n{character2}\n");

while (character1.Health > 0 && character2.Health > 0)
{
    var attacker = currentTurn == 0 ? character1 : character2;
    var defender = currentTurn == 1 ? character1 : character2;

    var attackerStats = attacker.Attack(defender);
    var defenderStats = defender.Attack(attacker);

    Console.WriteLine($"{attacker.Name} - Damage Taken: {defenderStats.damage}, Health: {(attacker.Health > 0 ? attacker.Health : 0)}");
    Console.WriteLine($"{defender.Name} - Damage Taken: {attackerStats.damage}, Health: {(defender.Health > 0 ? defender.Health : 0)}\n");
}

Console.WriteLine($"{(character1.Health > 0 ? character1 : character2).Name} wins!");

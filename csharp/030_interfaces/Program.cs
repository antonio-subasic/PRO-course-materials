// var mh = new IMiceHunter(); -> not possible
// IMiceHunter mh = new Owl(); -> possible

Animal[] zoo = [
    new Cat(),
    new Owl(),
    new Kiwi()
];

List<IMiceHunter> hunters = [
    new Cat(),
    new Owl()
];

HuntMice(hunters);

void HuntMice(IEnumerable<IMiceHunter> hunters)
{
    foreach (var hunter in hunters)
    {
        hunter.CatchMouse();
    }
}

abstract class Animal { }

abstract class Bird : Animal
{
    public virtual bool CanFly => true;
}

interface IMiceHunter
{
    void CatchMouse();
    void Something() => Console.WriteLine("something");
}

class Owl : Bird, IMiceHunter
{
    public void CatchMouse() => Console.WriteLine("watch - fly - catch");
}

class Kiwi : Bird
{
    public override bool CanFly => false;
}

class Cat : Animal, IMiceHunter
{
    public void CatchMouse() => Console.WriteLine("watch - jump - catch");
    public void SayMiau() => Console.WriteLine("Miau");
}

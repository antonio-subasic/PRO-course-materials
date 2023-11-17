AnimalInQueue? first = null;
AnimalInQueue? last = null;
// Queue is now empty

// Let's add an animal
var a = new AnimalInQueue("cat");
first = last = a;

// Let's add another animal
a = new AnimalInQueue("Fast horse");
last = first.Next = a;

// Let's add another animal
a = new AnimalInQueue("Axolotl");
last.Next = a;
last = a;

// Let's add another animal
a = new AnimalInQueue("Fish");
last.Next = a;
last = a;

// Let's take the first animal out
// Do something with first
first = first.Next;
if (first == null) { last = null; }

class AnimalInQueue(string name)
{
    public string Name { get; } = name;
    public AnimalInQueue? Next { get; set; }
}

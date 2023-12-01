using System.Text;

namespace Stirnreihe.Data;

public class LineOfPeople
{
    public Node? First { get; set; }

    public void AddToFront(Person person)
    {
        // set First to the new Node, which contains:
        // the person to be added
        // the old First as the next Node
        First = new(person, next: First);

        // set the previous of the next Node (old First) to the new Node
        if (First.Next is not null) { First.Next.Previous = First; }
    }

    public int AddSorted(Person person)
    {
        // if First is null
        // or the person to insert is shorter than the first person in the line
        if (First is null || person.Height < First.Person.Height)
        {
            AddToFront(person);
            return 0;
        }
        else
        {
            var index = 0;
            for (var current = First; ; current = current?.Next, index++)
            {
                // if the next Node is null (reached end of line)
                // or the person to insert is shorter than the next person in the line
                if (current?.Next is null || person.Height < current.Next.Person.Height)
                {
                    // set the current to the new Node, which contains:
                    // the person to be added
                    // the node after the current as the next Node
                    // the current as the previous Node
                    current = new(person, next: current?.Next, previous: current);

                    // set the previous of the next Node (old current.Next) to the new Node
                    if (current.Next is not null) { current.Next.Previous = current; }

                    // set the next of the previous Node (old current.Previous) to the new Node
                    if (current.Previous is not null) { current.Previous.Next = current; }

                    return index;
                }
            }
        }
    }

    public Person? RemovePersonAt(int index)
    {
        if (index == 0)
        {
            // get the first person from the line
            var person = First?.Person;

            // remove the first person from the line
            First = First?.Next;

            // set the previous pointer of the new first Node to null
            if (First is not null) { First.Previous = null; }

            // return the first person
            return person;
        }
        else
        {
            var idx = 0;

            for (var current = First; current is not null; current = current.Next, idx++)
            {
                // if the next Person is the Person to remove
                if (idx + 1 == index)
                {
                    // get the person from the next Node
                    var person = current.Next?.Person;

                    // remove the next Node
                    current.Next = current.Next?.Next;

                    // set the previous pointer of the new next Node to the current Node
                    if (current.Next is not null) { current.Next.Previous = current; }

                    // return the person
                    return person;
                }
            }
        }

        return null;
    }

    public void Sort()
    {
        bool somethingChanged;

        do
        {
            somethingChanged = false;

            for (var current = First; current is not null; current = current.Next)
            {
                // if the current person is taller than the next person
                if (current.Person.Height > current.Next?.Person.Height)
                {
                    // swap the persons
                    (current.Person, current.Next.Person) = (current.Next.Person, current.Person);
                    somethingChanged = true;
                }
            }
        } while (somethingChanged);
    }

    public void Clear()
    {
        // set First to null
        // when First is set to null, are elements become obsolete
        // and they get collected by the garbage collector
        First = null;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        // loop through linked list and add each person from current as a new line to the sb
        for (var current = First; current is not null; current = current.Next)
        {
            sb.AppendLine(current.Person.ToString());
        }

        return sb.ToString();
    }
}

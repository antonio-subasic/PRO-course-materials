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
        First = new(person, First);
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
            var old = First;
            var index = 0;

            for (var current = First?.Next; ; old = current, current = current?.Next, index++)
            {
                // if the current Node is null (reached end of line)
                // or the person to insert is shorter than the current person in the line
                if (current is null || person.Height < current.Person.Height)
                {
                    // set the old.Next to the new Node, which contains:
                    // the person to be added
                    // the current as the next Node
                    old.Next = new(person, current);
                    return index + 1;
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

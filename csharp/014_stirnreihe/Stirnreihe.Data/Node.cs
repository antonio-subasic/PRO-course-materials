namespace Stirnreihe.Data;

public class Node(Person person, Node? next = null, Node? previous = null)
{
    public Person Person { get; set; } = person;
    public Node? Next { get; set; } = next;
    public Node? Previous { get; set; } = previous;
}

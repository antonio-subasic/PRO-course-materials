namespace Stirnreihe.Data;

public class Person(string firstName, string lastName, int height)
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public int Height { get; } = height;

    public override string ToString() => $"{LastName}, {FirstName} ({Height} cm)";
}

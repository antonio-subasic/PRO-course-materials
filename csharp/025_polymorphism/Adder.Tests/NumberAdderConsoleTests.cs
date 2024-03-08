namespace Adder.Tests;

public class NumberAdderConsoleTests
{
    [Fact]
    public void AddingValidNumbers_ShouldPrintSums()
    {
        // Arrange
        var nacm = new NumberAdderConsoleMock(["5", "6", "q"]);

        // Act
        var result = nacm.AggregateEnteredNumbers();

        // Assert
        Assert.Equal(11, result);
        Assert.Equal([
            "Enter numbers, q to quit",
            "The current sum is 5",
            "The current sum is 11",
        ], nacm.Outputs);
    }

    [Fact]
    public void AddingWithInvalidNumbers_ShouldPrintError()
    {
        // Arrange
        var nacm = new NumberAdderConsoleMock(["5", "blablabla", "q"]);

        // Act
        var result = nacm.AggregateEnteredNumbers();

        // Assert
        Assert.Equal(5, result);
        Assert.Equal([
            "Enter numbers, q to quit",
            "The current sum is 5",
            "The number you entered is not valid",
        ], nacm.Outputs);
    }

    [Fact]
    public void AddingWithOverflow_ShouldPrintError()
    {
        // Arrange
        var nacm = new NumberAdderConsoleMock(["2147483647", "1", "q"]);

        // Act
        var result = nacm.AggregateEnteredNumbers();

        // Assert
        Assert.Equal(2147483647, result);
        Assert.Equal([
            "Enter numbers, q to quit",
            "The current sum is 2147483647",
            "The number you entered is too large",
        ], nacm.Outputs);
    }
}
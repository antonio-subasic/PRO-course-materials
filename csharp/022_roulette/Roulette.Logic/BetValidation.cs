namespace Roulette.Logic;

public enum MultiNumberBetType
{
    Street,
    Split,
    Square,
    SixLine
}

/// <summary>
/// Represents a multi-number bet on a roulette table.
/// </summary>
/// <remarks>
/// A bet can be constructed even if it is not valid.
/// To check if a bet is valid, call the <see cref="Validate"/> method.
/// </remarks>
public class Bet(MultiNumberBetType betType, HashSet<int> numbers)
{
    /// <summary>
    /// Checks if the bet is valid.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the bet is valid; otherwise, <c>false</c>.
    /// </returns>
    public bool Validate()
    {
        var possibleNumbers = new PossibleNumbers();
        var collection = betType switch
        {
            MultiNumberBetType.Street => possibleNumbers.Streets,
            MultiNumberBetType.Split => possibleNumbers.Splits,
            MultiNumberBetType.Square => possibleNumbers.Squares,
            MultiNumberBetType.SixLine => possibleNumbers.SixLines,
            _ => null
        };

        return collection is not null && Contains(collection, numbers);

    }

    /// <summary>
    /// Checks if a given set of numbers is in a list of sets of numbers.
    /// </summary>
    /// <param name="list">List of set of numbers in which to search</param>
    /// <param name="numbers">Numbers to search</param>
    /// <returns>
    /// <c>true</c> if the numbers are in the list; otherwise, <c>false</c>.
    /// </returns>
    public static bool Contains(List<HashSet<int>> list, HashSet<int> numbers)
        => list.Any(hashset => hashset.SetEquals(numbers));
}
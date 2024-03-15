using System.Globalization;

namespace WordGuesser.Tests;

public class WordGuessMockSingleWord : WordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a single, fixed word instead
    /// of a random word. This is useful for testing purposes.
    /// </remarks>
    public override string GetRandomWord() => "Test";
}

public class WordGuessMockWordGroup : WordGuess
{
    /// <summary>
    /// Gets the word to guess.
    /// </summary>
    /// <remarks>
    /// This method is overriden to return a fixed group of words instead
    /// of a random word. This is useful for testing purposes.
    /// </remarks>
    public override string GetRandomWord() => "Test Test";
}

public class NormalGuessTests
{
    [Fact]
    public void WordGuess_InitializesCurrentGuess_SingleWord()
    {
        // Use the WordGuessMockSingleWord class to test if 
        // the CurrentGuess property is initialized correctly.
        
        var game = new WordGuessMockSingleWord();

        Assert.Equal("____", game.CurrentGuess);
    }

    [Fact]
    public void WordGuess_InitializesCurrentGuess_WordGroup()
    {
        // Use the WordGuessMockWordGroup class to test if
        // the CurrentGuess property is initialized correctly when
        // the word to guess is a group of words.
        var game = new WordGuessMockWordGroup();

        Assert.Equal("____ ____", game.CurrentGuess);
    }

    [Fact]
    public void WordGuess_Guess_ReturnsTrue()
    {
        // Use the WordGuessMockSingleWord class to test if
        // the Guess method returns true when the guessed letter is in the word.
        // Use the letter "t" to also verify if the method is case-insensitive
        // and replaces all occurrences of the letter in the word.
        
        var game = new WordGuessMockSingleWord();

        Assert.True(game.Guess('t'));
        Assert.Equal("T__t", game.CurrentGuess);
    }

    [Fact]
    public void WordGuess_Guess_ReturnsFalse()
    {
        // Use the WordGuessMockSingleWord class to test if
        // the Guess method returns false when the guessed letter is not in the word.

        var game = new WordGuessMockSingleWord();

        Assert.False(game.Guess('z'));
        Assert.Equal("____", game.CurrentGuess);
    }
}
using WordGuesser;

Console.WriteLine("Welcome to Word Guesser!");


char input;
var isValid = false;

do
{
    Console.Write("Choose a difficulty - (n)ormal, (e)asy, (h)ard: ");
    input = char.ToLower(Console.ReadKey().KeyChar);

    if (!(isValid = input is 'n' or 'e' or 'h'))
    {
        Console.WriteLine("invalid input");
    }
} while (!isValid);


WordGuess game = input switch
{
    'n' => new WordGuess(),
    'e' => new EasyWordGuess(),
    'h' => new HardWordGuess(),
    _ => throw new InvalidOperationException()
};


var wrongGuesses = 0;

while (!game.Completed)
{
    Console.Clear();
    Console.WriteLine($"current guess: {game.CurrentGuess}");
    Console.WriteLine($"# wrong guesses: {wrongGuesses}");

    Console.Write("enter a letter: ");
    var letter = Console.ReadKey().KeyChar;

    if (!game.Guess(letter)) { wrongGuesses++; }
}


Console.Clear();
Console.WriteLine($"the word was: {game.CurrentGuess}");
Console.WriteLine($"# wrong guesses: {wrongGuesses}");

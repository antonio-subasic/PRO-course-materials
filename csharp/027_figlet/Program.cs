using WenceyWang.FIGlet;

var rendereres = new[]
{
    new TextRenderer(),
    new FigletRenderer("fonts/Bloody.flf"),
};

foreach (var renderer in rendereres)
{
    var text = new[] { "Hello World" };
    var renderedText = renderer.ReaderText(text);
    Console.WriteLine(string.Join("\n", renderedText));
}

class TextRenderer
{
    public virtual string[] ReaderText(string[] text) => text;
}

class FigletRenderer : TextRenderer
{
    private readonly FIGletFont? font;

    public FigletRenderer(string? fontPath = null)
    {
        if (fontPath is not null)
        {
            using var stream = File.OpenRead(fontPath);
            font = new FIGletFont(stream);
        }
    }

    public override string[] ReaderText(string[] text)
    {
        var result = new List<string>();

        foreach (var line in text)
        {
            var art = new AsciiArt(line, font);
            result.AddRange(art.ToString().Split('\n'));
        }

        return [.. result];
    }
}


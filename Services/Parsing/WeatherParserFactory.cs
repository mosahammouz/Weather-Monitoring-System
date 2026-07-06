namespace WeatherMind.Services.Parsing;

public class WeatherParserFactory
{
    private readonly List<(Func<string, bool> match, IWeatherParser parser)> _parsers;

    public WeatherParserFactory()
    {
        _parsers = new List<(Func<string, bool>, IWeatherParser)>
        {
            (input => input.TrimStart().StartsWith("{"), new JsonWeatherParser()),
            (input => input.TrimStart().StartsWith("<"), new XmlWeatherParser())
        };
    }

    public IWeatherParser GetParser(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input cannot be empty");

        var item = _parsers // this parser it will be the parser in an item in the list that its match(HOF) true so the answer of new() will be returned !
            .FirstOrDefault(p => p.match(input));// p is every item in the list (_parser)

        if (item.parser == null)
            throw new NotSupportedException("Unsupported format");

        return item.parser;//  new XmlWeatherParser() or  new JsonWeatherParser()
    }
}
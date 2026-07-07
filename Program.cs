using WeatherMind.Models;
using WeatherMind.Services.Input;
using WeatherMind.Services.Parsing;
using WeatherMind.Services.Config;
using WeatherMind.Services.Engine;
using WeatherMind.Services._05_Strategies;


var inputService = new WeatherInputService();
string rawInput = inputService.GetWeatherInput();

Console.WriteLine($"Raw input received: {rawInput}");


var factory = new WeatherParserFactory();
var parser = factory.GetParser(rawInput);

WeatherData data = parser.Parse(rawInput);

Console.WriteLine($"Parsed Data -> {data.Location} | {data.Temperature}° | {data.Humidity}%");


var configService = new ConfigService();// to load configurations

var strategies = new List<IWeatherStrategy>
{
    new RainStrategy(configService),
    new SunStrategy(configService),
    new SnowStrategy(configService)
};


var engine = new WeatherBotEngine(strategies); // Dependancy Injection 


engine.process(data);
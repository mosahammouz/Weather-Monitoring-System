using WeatherMind.Models;
using WeatherMind.Services.Input;
using WeatherMind.Services.Parsing;
using WeatherMind.Services.Config;
using WeatherMind.Services.Engine;
using WeatherMind.Services._05_Strategies;
using WeatherMind.Services._06_Bots;


var inputService = new WeatherInputService();
string rawInput = inputService.GetWeatherInput();  //input

Console.WriteLine($"Raw input received: {rawInput}");


var factory = new WeatherParserFactory();
var parser = factory.GetParser(rawInput);

WeatherData data = parser.Parse(rawInput); // parsing

Console.WriteLine($"Parsed Data -> {data.Location} | {data.Temperature}° | {data.Humidity}%" );


var configService = new ConfigService(); //Config



var rainStrategy = new RainStrategy(configService);
var sunStrategy = new SunStrategy(configService);
var snowStrategy = new SnowStrategy(configService);



var rainBot = new RainBot(rainStrategy);
var sunBot = new SunBot(sunStrategy);
var snowBot = new SnowBot(snowStrategy);


var engine = new WeatherBotEngine(); //Engine


engine.Register(rainBot);
engine.Register(sunBot);   //put them in the list 
engine.Register(snowBot);


engine.Process(data);
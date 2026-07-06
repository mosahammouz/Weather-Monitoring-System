using System.Runtime.Remoting;
using WeatherMind.Models;
using WeatherMind.Services.Input;
using WeatherMind.Services.Parsing;

var inputService = new WeatherInputService();
string rawInput = inputService.GetWeatherInput();
Console.WriteLine($"Raw input received: {rawInput}");
//
// XmlWeatherParser p = new XmlWeatherParser();
//  WeatherData obj = p.Parse(rawInput);
//  Console.WriteLine($"{obj.Location}(Location) - {obj.Humidity}(Humidity) - {obj.Temperature}(Temperature)");
//  
//  
//  WeatherParserFactory factory = new WeatherParserFactory();
//  var obj = factory.GetParser(rawInput);// obj(interface) is either XmlWeatherParser or JsonWeatherParser // we dont care which on is for obj
//  Console.WriteLine(obj.GetType().Name); 
// WeatherData data = obj.Parse(rawInput);
// Console.WriteLine($"{data.Location}(Location) - {data.Humidity}(Humidity) - {data.Temperature}(Temperature)");

using WeatherMind.Models;

namespace WeatherMind.Services.Parsing;

public class JsonWeatherParser: IWeatherParser
{
 public WeatherData Parse(string input)
 {
     return new WeatherData(); // not Implemented 
 }
}
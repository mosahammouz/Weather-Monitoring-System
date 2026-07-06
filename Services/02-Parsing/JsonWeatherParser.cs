using System.Text.Json;
using WeatherMind.Models;

namespace WeatherMind.Services.Parsing;

public class JsonWeatherParser: IWeatherParser
{
 public WeatherData Parse(string input)
 {
     var weatherDate = JsonSerializer.Deserialize<WeatherData>(input);//.Deserialize means convert from json string to an obj and its type is <WeatherData>  
     if (weatherDate is null)  throw new InvalidOperationException("Failed to parse weather data.");
     return weatherDate;
 }
}
using WeatherMind.Models;
namespace WeatherMind.Services.Parsing;

public interface IWeatherParser
{
    WeatherData Parse(string input);
}
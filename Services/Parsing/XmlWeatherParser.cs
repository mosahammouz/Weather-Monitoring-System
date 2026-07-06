using WeatherMind.Models;

namespace WeatherMind.Services.Parsing;

public class XmlWeatherParser: IWeatherParser
{
    public WeatherData Parse(string input)
    {
        return new WeatherData();//not implemented
    }
}
using System.Xml.Serialization;
using WeatherMind.Models;

namespace WeatherMind.Services.Parsing;

public class XmlWeatherParser : IWeatherParser
{
    public WeatherData Parse(string input)
    {
        var serializer = new XmlSerializer(typeof(WeatherData));
        using (StringReader reader = new StringReader(input)) // using for cleaning
        {
            var weatherData = serializer.Deserialize(reader) as WeatherData;//(as) is a safe casting operator.//anything error it will return null
            if (weatherData == null)
            {
                throw new InvalidOperationException("Failed to parse XML weather data.");
            }

            return weatherData;
        }
    }
}
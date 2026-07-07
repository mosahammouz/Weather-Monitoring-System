using WeatherMind.Models;
using WeatherMind.Services.Config;

namespace WeatherMind.Services._05_Strategies;
public class SunStrategy : IWeatherStrategy
{
    private readonly SunBotConfig _config;
    public SunStrategy(ConfigService config)
    {
        _config = config.SunBot;
    }
    public void Execute(WeatherData data)
    {
        if (!_config.Enabled) return;

        if (data.Temperature > _config.TemperatureThreshold)
        {
            Console.WriteLine("SunBot activated!");
            Console.WriteLine(_config.Message);
        }
    }
}
using WeatherMind.Models;
using WeatherMind.Services.Config;

namespace WeatherMind.Services._05_Strategies;
public class SnowStrategy : IWeatherStrategy
{
    private readonly SnowBotConfig _config;
    public SnowStrategy(ConfigService config)
    {
        _config = config.SnowBot;
    }
    public void Execute(WeatherData data)
    {
        if (!_config.Enabled) return;

        if (data.Temperature < _config.TemperatureThreshold)
        {
            Console.WriteLine("SnowBot activated!");
            Console.WriteLine(_config.Message);
        }
    }
}
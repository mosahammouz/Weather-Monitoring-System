using WeatherMind.Models;
using WeatherMind.Services.Config;

namespace WeatherMind.Services._05_Strategies;

public class RainStrategy : IWeatherStrategy
{
    private readonly RainBotConfig _config;

    public RainStrategy(ConfigService config)
    {
        _config = config.RainBot;
    }

    public void Execute(WeatherData data)
    {
        if (!_config.Enabled) return;

        if (data.Humidity > _config.HumidityThreshold)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine(_config.Message);
        }
    }
    
}
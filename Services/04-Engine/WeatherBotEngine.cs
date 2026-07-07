using WeatherMind.Models;
using WeatherMind.Services._05_Strategies;
using WeatherMind.Services.Config;


namespace WeatherMind.Services.Engine;

public class WeatherBotEngine
{
    private readonly List<IWeatherStrategy> _strategies;
    public WeatherBotEngine(List<IWeatherStrategy> strategies)
    {
        _strategies = strategies;
    }

    public void process(WeatherData data)
    {
        foreach (var strategy in _strategies)
        {
            strategy.Execute(data);
        }
    }
}
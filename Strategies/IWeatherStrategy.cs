using WeatherMind.Models;

namespace WeatherMind.Services._05_Strategies;

public interface IWeatherStrategy
{
    void Execute(WeatherData data);
}
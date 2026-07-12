using WeatherMind.Models;

namespace WeatherMind.Services._05_Observer;

public interface IWeatherObserver
{
    void Update(WeatherData data);
}
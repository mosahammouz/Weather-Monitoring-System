using WeatherMind.Models;

namespace WeatherMind.Services._05_Observer;

public interface IWeatherSubject
{
    void Register(IWeatherObserver observer);
    void Remove(IWeatherObserver observer);
    void Notify(WeatherData data);
}
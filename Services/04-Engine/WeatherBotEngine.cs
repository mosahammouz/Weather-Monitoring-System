using WeatherMind.Models;
using WeatherMind.Services._05_Observer;
using WeatherMind.Services._05_Strategies;
using WeatherMind.Services.Config;


namespace WeatherMind.Services.Engine;

public class WeatherBotEngine : IWeatherSubject
{
    private readonly List<IWeatherObserver> _observers =new();
    public void Register(IWeatherObserver observer)
    {
        _observers.Add(observer);
    }

    public void Remove(IWeatherObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(WeatherData data)
    {
        foreach(var observer in _observers)
        {
            observer.Update(data);
        }
    }

    public void Process(WeatherData data)
    {
        Notify(data);
    }
}
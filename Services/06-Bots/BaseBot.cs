using WeatherMind.Models;
using WeatherMind.Services._05_Observer;
using WeatherMind.Services._05_Strategies;

namespace WeatherMind.Services._06_Bots;

public abstract class BaseBot : IWeatherObserver
{
    private readonly IWeatherStrategy _strategy;
    
    protected BaseBot(IWeatherStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Update(WeatherData data)
    {    
        Console.WriteLine($"{GetType().Name} : received new weather update"); // the power of observer// we can send this as an email 
        _strategy.Execute(data);
    }
}
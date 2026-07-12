using Moq;
using WeatherMind.Models;
using WeatherMind.Services._05_Observer;
using WeatherMind.Services.Engine;

namespace WeatherMind.Tests.Services;

public class WeatherBotEngineTests
{
    [Fact]
    public void Process_Notifies_AllObservers()
    {
     
        var observer1 = new Mock<IWeatherObserver>();     // Arrange
        var observer2 = new Mock<IWeatherObserver>();

        var engine = new WeatherBotEngine();

        engine.Register(observer1.Object);
        engine.Register(observer2.Object);

        var data = new WeatherData
        {
            Location = "Miami",
            Temperature = 35,
            Humidity = 90
        };


       
        engine.Process(data); // Act


     
        observer1.Verify(
            o => o.Update(data),     // Assert
            Times.Once
        );

        observer2.Verify(
            o => o.Update(data),
            Times.Once
        );
    }
}
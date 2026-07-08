using Moq;
using WeatherMind.Models;
using WeatherMind.Services._05_Strategies;
using WeatherMind.Services.Engine;

namespace WeatherMind.Tests.Services;

public class WeatherBotEngineTests
{
    [Fact]
    public void Process_CallsExecute_OnEveryStrategy()
    {


        var strategy1 = new Mock<IWeatherStrategy>();
        var strategy2 = new Mock<IWeatherStrategy>();    //Arrange
        var engine = new WeatherBotEngine(new List<IWeatherStrategy> { strategy1.Object, strategy2.Object });
        var data = new WeatherData { Location = "Miami", Temperature = 35, Humidity = 90 };
        
        engine.process(data);//Act

        strategy1.Verify(s => s.Execute(data), Times.Once);  //Assert
        strategy2.Verify(s => s.Execute(data), Times.Once);
    }

}
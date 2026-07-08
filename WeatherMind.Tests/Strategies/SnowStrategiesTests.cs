using WeatherMind.Models;
using WeatherMind.Services._05_Strategies;
using WeatherMind.Services.Config;

namespace WeatherMind.Tests.Strategies;

public class SnowStrategyTests : IDisposable
{
    private readonly StringWriter _consoleOutput = new StringWriter();
    private readonly TextWriter _originalOutput = Console.Out;

    public SnowStrategyTests() => Console.SetOut(_consoleOutput);
    public void Dispose() => Console.SetOut(_originalOutput);

    [Fact]
    public void Execute_PrintsAlert_WhenTemperatureBelowThreshold() // stub test double
    {
        var config = new WeatherBotConfigRoot()  
        {
            SnowBot = new SnowBotConfig
                { Enabled = true, TemperatureThreshold = 0, Message = "Brrr, it's getting chilly!" }
        };
        var strategy = new SnowStrategy(config); // arrange

        strategy.Execute(new WeatherData { Temperature = -5 });  //act

        var output = _consoleOutput.ToString();
        Assert.Contains("SnowBot activated!", output);
        Assert.Contains("Brrr, it's getting chilly!", output); // assert
    }
}
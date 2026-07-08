using WeatherMind.Models;
using WeatherMind.Services._05_Strategies;
using WeatherMind.Services.Config;
using WeatherMind.Services.Parsing;
namespace WeatherMind.Tests;
using Moq;
public class RainStrategyTests
{
    [Fact] // it indicates that this method is a test 
    public void GetParser_WhenInputIsJson_ReturnsJsonWeatherParser()
    {

        var weatherParserFactory = new WeatherParserFactory(); // Arrange
        var jsonInput = """{ "Location": "Miami", "Temperature": 23.0, "Humidity": 85.0 }""";
        IWeatherParser parser = weatherParserFactory.GetParser(jsonInput); // Act
        Assert.IsType<JsonWeatherParser>(parser); // Assert
    }

    [Fact]
    public void Execute_WritesAlert_WhenHumidityExceedsThreshold()
    {
        // Arrange
        var configFolder = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Config");

        Directory.CreateDirectory(configFolder);

        var configPath = Path.Combine(
            configFolder,
            "botconfig.json");

        File.WriteAllText(configPath,
            """
            {
              "RainBot": {
                "Enabled": true,
                "HumidityThreshold": 80,
                "Message": "Bring an umbrella!"
              }
            }
            """);

        var configService = new ConfigService();

        var strategy = new RainStrategy(configService);

        var data = new WeatherData
        {
            Humidity = 90
        };

        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        strategy.Execute(data);

        // Assert
        var output = consoleOutput.ToString();

        Assert.Contains("RainBot activated!", output);
        Assert.Contains("Bring an umbrella!", output);
    }
}
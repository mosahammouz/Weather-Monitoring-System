namespace WeatherMind.Models;

public class SnowBotConfig: BaseBotConfig
{
    public double TemperatureThreshold { get; set; }
    public SnowBotConfig(){}

    public SnowBotConfig(bool enabled, string message, double temperatureThreshold)
   : base(enabled, message)
    {
        TemperatureThreshold = temperatureThreshold;
    }
}
namespace WeatherMind.Models;

public class SunBotConfig : BaseBotConfig
{
    public double TemperatureThreshold { get; set; }
   public SunBotConfig(){}

    SunBotConfig(bool enabled, string message, double temperatureThreshold)
        : base(enabled, message)
    {
        TemperatureThreshold = temperatureThreshold;
    }
    
}
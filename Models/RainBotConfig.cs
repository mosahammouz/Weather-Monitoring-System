namespace WeatherMind.Models;

public class RainBotConfig : BaseBotConfig
{
    public double HumidityThreshold { get; set; }
    public RainBotConfig() { }
    public RainBotConfig(bool enabled, string message, double humidityThreshold) 
              : base(enabled, message) { HumidityThreshold = humidityThreshold; }
    
}
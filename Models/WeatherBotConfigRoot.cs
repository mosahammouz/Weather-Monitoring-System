namespace WeatherMind.Models;

public class WeatherBotConfigRoot
{
    public RainBotConfig RainBot { get; set; }
    public SunBotConfig SunBot { get; set; }
    public SnowBotConfig SnowBot { get; set; }
}
namespace WeatherMind.Models;

public class BaseBotConfig
{
    public bool Enabled { get; set; }
    public string Message { get; set; }
    public BaseBotConfig(){}
    public BaseBotConfig(bool enabled , string msg)
    {
        Enabled = enabled;
        Message = msg;
    }
}
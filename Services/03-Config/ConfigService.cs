using WeatherMind.Models;
namespace WeatherMind.Services.Config;
using System.Text.Json;
public class ConfigService
{
     private readonly WeatherBotConfigRoot _config; // for stor

     public ConfigService()
     {
          var path =  Path.Combine(Directory.GetCurrentDirectory(), "Config", "botconfig.json");
          if(!File.Exists(path))throw new FileNotFoundException($"botconfig.json not found at: {path}");
          var json = File.ReadAllText(path);
          _config = JsonSerializer.Deserialize<WeatherBotConfigRoot>(json,
               new JsonSerializerOptions
               {
                    PropertyNameCaseInsensitive = true
               })!;
     }
     public RainBotConfig RainBot => _config.RainBot;
     public SunBotConfig SunBot => _config.SunBot;
     public SnowBotConfig SnowBot => _config.SnowBot;
}
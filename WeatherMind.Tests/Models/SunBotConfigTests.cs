using WeatherMind.Models;

namespace WeatherMind.Tests.Models;

public class SunBotConfigTests
{
    [Fact]
    public void SunBotConfig_WhenCreatedWithValues_SetsPropertiesCorrectly()
    {   
        var enabled = true;      //arrange
        var message = "Sun detected";
        var sunBotConfig = new SunBotConfig(enabled,message,35); //act
        Assert.True(sunBotConfig.Enabled);
        Assert.Equal(message, sunBotConfig.Message);

    }
}
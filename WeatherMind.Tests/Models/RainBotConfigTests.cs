using WeatherMind.Models;

namespace WeatherMind.Tests.Models;

public class RainBotConfigTests
{
    [Fact]
    public void RainBotConfig_WhenCreatedWithValues_SetsPropertiesCorrectly()
    {   
        var enabled = true;      //arrange
        var message = "Rain detected";
        var rainBotConfig = new RainBotConfig(enabled,message,3); //act
        Assert.True(rainBotConfig.Enabled);
        Assert.Equal(message, rainBotConfig.Message);

    }
}
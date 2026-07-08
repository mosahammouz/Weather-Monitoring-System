using System;
using Xunit;
using WeatherMind.Services.Parsing;

namespace WeatherMind.Tests.Parsing
{
    public class JsonWeatherParserTests
    {
        [Fact]
        public void Parse_ReturnsWeatherData_ForValidJson()
        {
            var parser = new JsonWeatherParser();
            var json = "{ \"Location\": \"Miami\", \"Temperature\": 23.0, \"Humidity\": 85.0 }";

            var result = parser.Parse(json); //Act

            Assert.Equal("Miami", result.Location);
            Assert.Equal(23.0, result.Temperature);
            Assert.Equal(85.0, result.Humidity);
        }

        [Fact]
        public void Parse_Throws_WhenJsonIsMalformed()
        {
            var parser = new JsonWeatherParser();

            Assert.ThrowsAny<Exception>(() => parser.Parse("{ not valid json"));
        }

        [Fact]
        public void Parse_ThrowsInvalidOperationException_WhenJsonIsNullLiteral()
        {
            var parser = new JsonWeatherParser();

            // JsonSerializer.Deserialize<T>("null") returns null for reference types,
            // which hits your explicit null-check and throws InvalidOperationException
            Assert.Throws<InvalidOperationException>(() => parser.Parse("null"));
        }

        [Fact]
        public void Parse_HandlesMissingFields_UsingDefaults()
        {
            var parser = new JsonWeatherParser();
            var json = "{ \"Location\": \"Miami\" }"; // Temperature/Humidity omitted

            var result = parser.Parse(json);

            Assert.Equal("Miami", result.Location);
            Assert.Equal(0, result.Temperature); // default(double)
            Assert.Equal(0, result.Humidity);
        }
    }
}
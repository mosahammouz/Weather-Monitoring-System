using System;
using System.IO;
using Xunit;
using WeatherMind.Services.Input;

namespace WeatherMind.Tests.Input
{
    public class WeatherInputServiceTests : IDisposable
    {
        private readonly TextWriter _originalOutput = Console.Out;
        private readonly TextReader _originalInput = Console.In;

        // restore real Console streams after each test, so tests don't leak into each other
        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            Console.SetIn(_originalInput);
        }

        [Fact]
        public void GetWeatherInput_ReturnsWhateverWasTyped()
        {
            Console.SetIn(new StringReader("{ \"Location\": \"Miami\" }")); // fake user input
            Console.SetOut(new StringWriter());                           // swallow the prompt

            var service = new WeatherInputService();
            var result = service.GetWeatherInput();

            Assert.Equal("{ \"Location\": \"Miami\" }", result);
        }

        [Fact]
        public void GetWeatherInput_ReturnsNull_WhenInputStreamIsEmpty()
        {
            Console.SetIn(new StringReader(string.Empty));
            Console.SetOut(new StringWriter());

            var service = new WeatherInputService();
            var result = service.GetWeatherInput();

            Assert.Null(result);
        }

        [Fact]
        public void GetWeatherInput_PrintsPrompt_BeforeReadingInput()
        {
            var output = new StringWriter();
            Console.SetIn(new StringReader("some input"));
            Console.SetOut(output);

            var service = new WeatherInputService();
            service.GetWeatherInput();

            Assert.Contains("Enter weather data:", output.ToString());
        }
    }
}
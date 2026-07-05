using WeatherMind.Services.Input;

var inputService = new WeatherInputService();
string rawInput = inputService.GetWeatherInput();
Console.WriteLine($"Raw input received: {rawInput}");
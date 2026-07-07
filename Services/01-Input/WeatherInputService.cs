namespace WeatherMind.Services.Input;

public class WeatherInputService
{
    public string GetWeatherInput()
    {
        Console.WriteLine("Enter weather data:");
        string input = Console.ReadLine();

        return input;
    }
}
namespace WeatherMind.Models;

public class WeatherData
{
    public string Location { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public WeatherData(){}
    public WeatherData(string loc, double temp, double humidity)
    {
        Location = loc;
        Temperature = temp;
        Humidity = humidity;
    }
}
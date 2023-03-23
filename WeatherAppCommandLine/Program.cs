using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using WeatherApp.API;
using WeatherApp.WeatherDetails;
using WeatherAppCommandLine;

public class Program
{
    
    public static void Main(string[] args)
    { 
        IHost _host=Host.CreateDefaultBuilder().ConfigureServices(
            services =>
            {
                services.AddTransient<IWeatherAppApi,WeatherAppAPI>();
                services.AddTransient<IWeatherDetails, WeatherDetails>();
                services.AddTransient<IDisplayWeather, DisplayWeather>();

            }).Build();
        while (true)
        {
            Console.WriteLine("Enter the city : ");
            
            var city = Console.ReadLine();

            var app=_host.Services.GetRequiredService<IDisplayWeather>();
            app.display(city);
                        
        }

       
       
    }
   
}
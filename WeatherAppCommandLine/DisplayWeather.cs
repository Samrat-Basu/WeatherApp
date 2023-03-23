using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API;
using WeatherApp.WeatherDetails;
using WeatherAPP.Models.Modals;

namespace WeatherAppCommandLine
{
    public class DisplayWeather : IDisplayWeather
    {
        IWeatherDetails _weatherDetails;
        IWeatherAppApi _weatherAppApi;
        public DisplayWeather(IWeatherDetails weatherDetails,IWeatherAppApi weatherAppApi)
        {
            _weatherDetails = weatherDetails;
            _weatherAppApi = weatherAppApi;
        }       
        public async void display(string city)
        {
            var latitude = await _weatherDetails.getLatitude(city);
            try
            {
                var longitude = await _weatherDetails.getLongitude(city);

                var weatherAndAreaDetails = _weatherAppApi.GetWeatherAndAreaDetails(latitude, longitude);

                if ((latitude == 0) && (longitude == 0))
                {
                    Console.WriteLine("No data found");
                }
                else
                {
                    Console.WriteLine($"Longitude : {latitude}");
                    Console.WriteLine($"Longitude : {longitude}");
                    Console.WriteLine($"Temperature : {weatherAndAreaDetails.Result.current_weather.temperature}");
                    Console.WriteLine($"Wind speed : {weatherAndAreaDetails.Result.current_weather.windspeed}");
                    Console.WriteLine($"Wind Direction : {weatherAndAreaDetails.Result.current_weather.winddirection}");
                    Console.WriteLine($"Weather Code : {weatherAndAreaDetails.Result.current_weather.weathercode}");
                    Console.WriteLine($"Time : {weatherAndAreaDetails.Result.current_weather.time}");
                    //Console.WriteLine($"Temperature : {weatherAndAreaDetails.Result.current_weather.temperature}");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

       
    }
}

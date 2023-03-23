using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Models.Modals;
using System.IO;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace WeatherApp.WeatherDetails
{
    public class WeatherDetails : IWeatherDetails
    {
        IConfiguration _configuration;
        public WeatherDetails(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Coordinates>> ReadDataFromCSV()
        {
            
            //var filePath= "@\"E:\\\\WeatherAppCLI\\\\WeatherApp\\\\WeatherAppCommandLine\\\\WeatherApp.WeatherDetails\\\\CityData\\\\CityData.csv\"
            var filePath = _configuration.GetRequiredSection("Settings").Get<Settings>().filePath;
            List<Coordinates> values = File.ReadAllLines(filePath)
                                              .Skip(1)
                                              .Select(v => Coordinates.FromCsv(v))
                                              .ToList();

            return values;
        }

        public async Task<decimal> getLatitude(string cityToFetchLat)
        {
            var csvdata = await ReadDataFromCSV();
            //Console.WriteLine(csvdata.Count);

            decimal latitide = 0;

            foreach (var city in csvdata)
            {
                if (cityToFetchLat.ToString().ToUpper() == city.city.ToUpper())
                {
                    latitide = city.latitude;
                }
            }
            return latitide;
        }


        public async Task<decimal> getLongitude(string cityToFetchLng)
        {
            var csvdata = await ReadDataFromCSV();

            decimal longitude = 0;

            foreach (var city in csvdata)
            {
                if (cityToFetchLng.ToString().ToUpper() == city.city.ToUpper())
                {
                    longitude = city.longitude;
                }

            }
            return longitude;
        }

    }
}

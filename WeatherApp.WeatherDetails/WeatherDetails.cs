using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Models.Modals;
using System.IO;
using System.Configuration;

namespace WeatherApp.WeatherDetails
{
    public class WeatherDetails:IWeatherDetails
    {
        string filePath = ConfigurationManager.AppSettings["filePath"];
        public async Task<List<Coordinates>> ReadDataFromCSV()
        {         
           List<Coordinates> values =File.ReadAllLines(@"E:\\WeatherAppCLI\\WeatherApp\\WeatherAppCommandLine\\WeatherApp.WeatherDetails\\CityData\\CityData.csv")
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

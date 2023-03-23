using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Models.Modals;

namespace WeatherApp.WeatherDetails
{
    public interface IWeatherDetails
    {   
        Task<decimal> getLatitude(string cityToFetchLat);
        Task<decimal> getLongitude(string cityToFetchLng);
        Task<List<Coordinates>> ReadDataFromCSV();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Models.Modals;

namespace WeatherApp.API
{
    public interface IWeatherAppApi
    {
        Task<WeatherAndAreaDetails> GetWeatherAndAreaDetails(decimal latitude, decimal longitude);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPP.Models.Modals
{
    public class CurrentWeather
    {
        [property: JsonPropertyName("temperature")]
        public double temperature { get; set; }

        [property: JsonPropertyName("windspeed")]
        public double windspeed { get; set; }

        [property: JsonPropertyName("winddirection")]
        public double winddirection { get; set; }

        [property: JsonPropertyName("weathercode")]
        public int weathercode { get; set; }

        [property: JsonPropertyName("time")]
        public string? time { get; set; }
    }
 
}

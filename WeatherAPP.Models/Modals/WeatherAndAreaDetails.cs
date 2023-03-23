using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPP.Models.Modals
{
    public class WeatherAndAreaDetails
    {
        [property: JsonPropertyName("latitude")]
        public double latitude { get; set; }

        [property: JsonPropertyName("longitude")]
        public double longitude { get; set; }

        [property: JsonPropertyName("generationtime_ms")]
        public double generationtime_ms { get; set; }

        [property: JsonPropertyName("utc_offset_seconds")]
        public int utc_offset_seconds { get; set; }

        [property: JsonPropertyName("timezone")]
        public string? timezone { get; set; }

        [property: JsonPropertyName("timezone_abbreviation")]
        public string? timezone_abbreviation { get; set; }

        [property: JsonPropertyName("elevation")]
        public double elevation { get; set; }

        [property: JsonPropertyName("current_weather")]
        public CurrentWeather? current_weather { get; set; }
    }
}

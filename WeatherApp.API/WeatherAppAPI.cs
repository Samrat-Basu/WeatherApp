using System.Text.Json;
using WeatherAPP.Models.Modals;

namespace WeatherApp.API
{
    public class WeatherAppAPI:IWeatherAppApi
    {
        public async Task<WeatherAndAreaDetails> GetWeatherAndAreaDetails(decimal latitude,decimal longitude)
        {
            WeatherAndAreaDetails weatherAndAreaDetails;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");

                    using (HttpResponseMessage res = client.GetAsync(client.BaseAddress).Result)
                    {

                        using (HttpContent content = res.Content)
                        {

                            var data = await content.ReadAsStringAsync();

                            weatherAndAreaDetails = JsonSerializer.Deserialize<WeatherAndAreaDetails>(data);
                            return weatherAndAreaDetails;

                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }

            return new WeatherAndAreaDetails();
        }
    }
}
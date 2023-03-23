using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP.Models.Modals;

namespace WeatherApp.Tests.Mock
{
    public class ReadCSVMockData
    {
        public static async Task<List<Coordinates>> GetCoordinates()
        {
            return new List<Coordinates>()
            {
                new Coordinates
                {
                    city="Delhi",
                    longitude=13.1234M,
                    latitude=23.34M

                },
                 new Coordinates
                {
                    city="Kolkata",
                    longitude=21.1234M,
                    latitude=17.34M
                },
                new Coordinates
                {
                     city="Ludhiana",
                    longitude=11.1234M,
                    latitude=13.34M
                },
                new Coordinates
                {
                     city="Mumbai",
                    longitude=10.1234M,
                    latitude=3.34M
                },

            };
        }
    }
}

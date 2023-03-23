using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPP.Models.Modals
{
    public class Coordinates
    {
        public string? city { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }

        public static Coordinates FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Coordinates loc = new Coordinates();
            loc.city = RemoveDiacritics(values[0].Trim());
            loc.latitude = Convert.ToDecimal(values[1]);
            loc.longitude = Convert.ToDecimal(values[2]);
            return loc;
        }

        //cleaning the data
        public static String RemoveDiacritics(String s)
        {

            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
}

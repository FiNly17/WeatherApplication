using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication
{
    public static class FileConfig
    {
        public static string CurrentWeatherAPI = System.Configuration.ConfigurationManager.AppSettings.Get("CurrentWeatherAPI");

        public static string ForecastWeatherAPI = System.Configuration.ConfigurationManager.AppSettings.Get("ForecastWeatherAPI");

        public static string APIKey = System.Configuration.ConfigurationManager.AppSettings.Get("ApiKey");

        public static int minValue = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("MinimumAllowable"));

        public static int maxValue = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("MaximumAllowable"));
    }
}

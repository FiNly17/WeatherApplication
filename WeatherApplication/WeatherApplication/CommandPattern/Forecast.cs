using BLL.Patterns.Strategy;
using Newtonsoft.Json;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherApplication.CommandPattern
{
    public class Forecast
    {
        private readonly HttpClient client = new HttpClient();

        public async Task GetForecastWeather()
        {
            CurrentCity currentCity = new CurrentCity();
            Console.WriteLine("Enter your city: ");
            string city = Console.ReadLine();
            var response = await client.GetAsync(GetCurrentWeatherAPICall(city));

            if (response.IsSuccessStatusCode)
                currentCity = await response.Content.ReadAsAsync<CurrentCity>();

            Console.WriteLine("Enter days of forecast");
            int days = Convert.ToInt32(Console.ReadLine());

            while(days < FileConfig.minValue || days > FileConfig.maxValue)
            {
                Console.WriteLine("Incorrect number of days");
                Console.WriteLine("Enter days of forecast");
                days = Convert.ToInt32(Console.ReadLine());
            }

            var responseForecast = await GetHttpResponseAsync(currentCity);

            await ShowForecastInformation(responseForecast, city, days);
        }

        public async Task<HttpResponseMessage> GetHttpResponseAsync(CurrentCity currentCity)
        {
            return await client.GetAsync(GetForecastWeatherAPICall(currentCity.Coordinate.Latitude, currentCity.Coordinate.Longtitude));
        }

        public async Task ShowForecastInformation(HttpResponseMessage responseForecast, string city, int days)
        {
            if (responseForecast.IsSuccessStatusCode)
            {
                string currentCities = await responseForecast.Content.ReadAsStringAsync();

                double?[] a = GetArrayOfTemperature(currentCities, days);

                Context context = new Context(city, null, a);
                context.GetInformation();
            }
        }

        public double?[] GetArrayOfTemperature(string temperatures, int days)
        {
            Regex firstRegex = new Regex(@"(day)(\W{2})([0-9]+)(\W?)([0-9]+)(\W+)(m)");
            Regex secondRegex = new Regex(@"([0-9]+)(\W?)([0-9]+)");
            MatchCollection matches = firstRegex.Matches(temperatures);
            double?[] a = new double?[days];
            int i = 0;

            foreach (Match match in matches)
            {
                MatchCollection matchCollection = secondRegex.Matches(match.Value);
                foreach (Match m in matchCollection)
                {
                    if (i < days)
                    {
                        a[i] = Convert.ToDouble(m.Value.Replace('.', ','));
                        i++;
                    }
                }
            }

            return a;
        }

        public string GetCurrentWeatherAPICall(string city)
        {
            return $"{FileConfig.CurrentWeatherAPI}&q={city}&{FileConfig.APIKey}";
        }

        public string GetForecastWeatherAPICall(double latitude, double longtitude)
        {
            return $"{FileConfig.ForecastWeatherAPI}lat={latitude}&lon={longtitude}&exclude=hourly,minutely,alerts,current&units=metric&{FileConfig.APIKey}";
        }
    }
}

using BLL.Patterns.Strategy;
using DAL.UOW;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.CommandPattern
{
    public class Current
    {
        private readonly HttpClient client = new HttpClient();
        public async Task GetCurrentWeather()
        {
            CurrentCity currentCity = new CurrentCity();
            Console.WriteLine("Enter your city: ");
            string city = Console.ReadLine();
            DateTime start = DateTime.Now;
            var response = await client.GetAsync(GetCurrentWeatherAPICall(city));
            DateTime end = DateTime.Now;
            Console.WriteLine((end - start).TotalMilliseconds);

            if (response.IsSuccessStatusCode)
            {
                currentCity = await response.Content.ReadAsAsync<CurrentCity>();

                Context context = new Context(currentCity.Name, currentCity.Main.Temperature, null);
                context.GetInformation();
            }
        }

        public string GetCurrentWeatherAPICall(string city)
        {
            return $"{FileConfig.CurrentWeatherAPI}&q={city}&{FileConfig.APIKey}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.CommandPattern
{
    public class ForecastOnCommand : ICommand
    {
        Forecast forecast { get; set; }

        public ForecastOnCommand(Forecast forecast)
        {
            this.forecast = forecast;
        }

        public async Task Execute()
        {
            await forecast.GetForecastWeather();
        }
    }
}

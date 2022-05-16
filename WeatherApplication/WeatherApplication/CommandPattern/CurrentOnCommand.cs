using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.CommandPattern
{
    public class CurrentOnCommand : ICommand
    {
        Current current { get; set; }

        public CurrentOnCommand(Current current)
        {
            this.current = current;
        }

        public async Task Execute()
        {
            await current.GetCurrentWeather();
        }
    }
}

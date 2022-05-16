using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Patterns.Strategy
{
    public class BeachWeather : IWeather
    {
        public string ShowTemp()
        {
            return "It's time to go to the beach";
        }
    }
}

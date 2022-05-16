using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Patterns.Strategy
{
    public class FreshWeather : IWeather
    {
        public string ShowTemp()
        {
            return "It's fresh";
        }
    }
}

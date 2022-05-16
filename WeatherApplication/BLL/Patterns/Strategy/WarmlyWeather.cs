using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Patterns.Strategy
{
    public class WarmlyWeather : IWeather
    {
        public string ShowTemp()
        {
            return "Dress warmly";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.CommandPattern
{
    public interface ICommand
    {
        Task Execute();
    }
}

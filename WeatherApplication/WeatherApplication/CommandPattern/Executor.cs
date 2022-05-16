using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.CommandPattern
{
    public class Executor
    {
        ICommand command;

        public Executor() { }

        public void SetCommand(ICommand command) 
        {
            this.command = command;
        }

        public async Task Do()
        {
            if(command != null)
                await command.Execute();
        }
    }
}

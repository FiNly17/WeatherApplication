using ObjectLayer;

namespace BLL.Patterns.Strategy
{
    public class Context
    {
        public IWeather weather { get; set; }

        private readonly string city;

        private readonly double? temp;

        private readonly double?[] arrayTemp;


        public Context(string city, double? temp, double?[] arrayTemp)
        {
            this.city = city;
            this.temp = temp;
            this.arrayTemp = arrayTemp;
        }

        public void GetInformation()
        {
            if(temp != null)
            {
                GetTypeWeather(temp);
                Console.WriteLine($"In {city} {Math.Round(Convert.ToDecimal(temp), 2)} C. {this.weather.ShowTemp()}.");
            }
            else
            {
                int size = arrayTemp.Length;
                Console.WriteLine($"{city} weather forecast:");
                for(int i = 0; i < size; i++)
                {
                    GetTypeWeather(arrayTemp[i]);
                    Console.WriteLine($"Day {i + 1}: {arrayTemp[i].Value} C. {this.weather.ShowTemp()}");
                }
            }
        }

        public void GetTypeWeather(double? temp)
        {
            if (temp < 0.00f)
                this.weather = new WarmlyWeather();
            else if (temp >= 0 && temp < 20.00f)
                this.weather = new FreshWeather();
            else if (temp >= 20.00f && temp <= 30.00f)
                this.weather = new GoodWeather();
            else
                this.weather = new BeachWeather();
        }
    } 
}

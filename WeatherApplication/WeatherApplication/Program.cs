using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WeatherApplication;
using ObjectLayer;
using BLL.Patterns.Strategy;
using DAL.UOW;
using WeatherApplication.CommandPattern;
using Autofac;
using BLL.Services;
using BLL.IServices;

static async Task ProcessRepositories(HttpClient client)
{
    Executor executor = new Executor();
    Current current = new Current();
    Forecast forecast = new Forecast();

    int number = 99;
    do 
    {
        Console.WriteLine("Choose the number:\n" +
                                 "1.Current weather\n" +
                                 "2.Weather forecast\n" +
                                 "0.Close application");
        number = Convert.ToInt32(Console.ReadLine());
        switch (number)
        {
            case 0:
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

            case 1:
                {
                    executor.SetCommand(new CurrentOnCommand(current));
                    await executor.Do();
                    break;
                }
            case 2:
                {
                    executor.SetCommand(new ForecastOnCommand(forecast));
                    await executor.Do();
                    break;
                }

            default:
                {
                    Console.WriteLine("Choose another one number!");
                    break;
                }

        }
    } while (number != 0);
    



    //CurrentCity currentCity = new CurrentCity();
    //string city = "Minsk";
    //var response = await client.GetAsync($"{System.Configuration.ConfigurationManager.AppSettings.Get("CurrentWeatherAPI")}q={city}&{System.Configuration.ConfigurationManager.AppSettings.Get("ApiKey")}");

    //if (response.IsSuccessStatusCode)
    //    currentCity = await response.Content.ReadAsAsync<CurrentCity>();


    //WeatherContext _context = new WeatherContext();
    //IUnitOfWork uow = new UnitOfWork(_context);

    //TestClass testClass = new TestClass(uow);

    //bool flag = await testClass.CreateRow(currentCity);

    //if (flag)
    //    Console.WriteLine("Was Added");
    //else
    //    Console.WriteLine("Have some problems");

    //IEnumerable<CurrentCity> currentCities = await testClass.GetAll();

    //foreach(var c in currentCities)
    //{
    //    Context context = new Context(c);
    //    context.GetInformation();
    //}
}

//AutoFac
static IContainer ConfigureContainer()
{
    var builder = new ContainerBuilder();

    builder.RegisterType<CloudsService>().As<ICloudsService>();
    // Register all dependencies (and dependencies of those dependencies, etc)

    return builder.Build();
}

//Default DI with creating StartUp class
IHost host = Host.CreateDefaultBuilder(args).Build();

IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
IServiceCollection services = new ServiceCollection();
Startup startup = new Startup(config);
startup.ConfigureServices(services);
IServiceProvider serviceProvider = services.BuildServiceProvider();

HttpClient client = new HttpClient();
await ProcessRepositories(client);


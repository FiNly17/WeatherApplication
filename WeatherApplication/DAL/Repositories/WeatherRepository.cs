using DAL.IRepositories;
using ObjectLayer;

namespace DAL.Repositories
{
    public class WeatherRepository : Repository<Weather>, IWeatherRepository
    {
        public WeatherRepository(WeatherContext context)
            : base(context)
        { }
    }
}

using DAL.IRepositories;
using ObjectLayer;

namespace DAL.Repositories
{
    public class CurrentCityRepository : Repository<CurrentCity>, ICurrentCityRepository
    {
        public CurrentCityRepository(WeatherContext context)
            : base(context)
        { }
    }
}

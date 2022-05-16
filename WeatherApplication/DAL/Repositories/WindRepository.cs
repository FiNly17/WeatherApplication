using DAL.IRepositories;
using ObjectLayer;

namespace DAL.Repositories
{
    public class WindRepository : Repository<Wind>, IWindRepository
    {
        public WindRepository(WeatherContext context)
            : base(context)
        { }
    }
}

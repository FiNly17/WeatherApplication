using DAL.IRepositories;
using ObjectLayer;

namespace DAL.Repositories
{
    public class SysRepository : Repository<Sys>, ISysRepository
    {
        public SysRepository(WeatherContext context)
            : base(context)
        { }
    }
}

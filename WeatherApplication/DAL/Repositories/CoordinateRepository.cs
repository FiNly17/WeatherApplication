using DAL.IRepositories;
using ObjectLayer;

namespace DAL.Repositories
{
    public class CoordinateRepository : Repository<Coordinate>, ICoordinateRepository
    {
        public CoordinateRepository(WeatherContext context)
            : base(context)
        { }
    }
}

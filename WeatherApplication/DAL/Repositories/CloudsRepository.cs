using DAL.IRepositories;
using ObjectLayer;

namespace DAL.Repositories
{
    public class CloudsRepository : Repository<Clouds>, ICloudsRepository
    {
        public CloudsRepository(WeatherContext context)
            : base(context)
        { }
    }
}

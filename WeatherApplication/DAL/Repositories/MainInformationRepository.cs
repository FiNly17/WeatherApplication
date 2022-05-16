using DAL.IRepositories;
using ObjectLayer;

namespace DAL.Repositories
{
    public class MainInformationRepository : Repository<MainInformation>, IMainInformationRepository
    {
        public MainInformationRepository(WeatherContext context)
            : base(context)
        { }
    }
}

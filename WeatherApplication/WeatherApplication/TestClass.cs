using BLL.IServices;
using BLL.Services;
using DAL.UOW;
using ObjectLayer;

namespace WeatherApplication
{
    public class TestClass
    {
        private readonly ICloudsService cloudsService;
        private readonly ICoordinateService coordinateService;
        private readonly ICurrentCityService currentCityService;
        private readonly IMainInformationService mainInformationService;
        private readonly ISysService sysService;
        private readonly IWeatherService weatherService;
        private readonly IWindService windService;

        public TestClass(IUnitOfWork unitOfWork)
        {
            this.cloudsService = new CloudsService(unitOfWork);
            this.currentCityService = new CurrentCityService(unitOfWork);
            this.coordinateService = new CoordinateService(unitOfWork);
            this.mainInformationService = new MainInformationService(unitOfWork);
            this.sysService = new SysService(unitOfWork);
            this.weatherService = new WeatherService(unitOfWork);
            this.windService = new WindService(unitOfWork);
        }

        public async Task<bool> CreateRow(CurrentCity city)
        {
            if (await currentCityService.CreateCurrentCity(city) != null)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<CurrentCity>> GetAll()
        {
            IEnumerable<CurrentCity> cities = await currentCityService.GetAllCurrentCities();

            foreach(var city in cities)
            {
                city.Clouds = await cloudsService.GetCloudById(city.CloudsId);
                city.Coordinate = await coordinateService.GetCoordinateById(city.CoordinateId);
                city.Main = await mainInformationService.GetMainInformationById(city.MainId);
                city.Sys = await sysService.GetSysById(city.SysId);
                city.Wind = await windService.GetWindById(city.WindId);
                city.Weather = (await weatherService.GetWeathersByConditions(weath => weath.CurrentCityId == city.CurrentCityId)).ToList();
            }

            return cities;
        }
    }
}

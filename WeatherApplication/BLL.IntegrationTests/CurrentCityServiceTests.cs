using BLL.IServices;
using BLL.Services;
using DAL.UOW;
using ObjectLayer;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BLL.IntegrationTests
{
    public class CurrentCityServiceTests : IClassFixture<WeatherContext>
    {
        private readonly WeatherContext weatherContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentCityService _currentCityService;

        public CurrentCityServiceTests(WeatherContext weatherContext)
        {
            this.weatherContext = weatherContext;
            _unitOfWork = new UnitOfWork(this.weatherContext);
            _currentCityService = new CurrentCityService(_unitOfWork);
        }
        //Check GetAll
        [Fact]
        public async Task IsGetAllCitiesReturnsEverything()
        {
            //Act
            var result = await _currentCityService.GetAllCurrentCities();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<CurrentCity>>(result);
            Assert.Equal(1, model.Count());
        }

        //Check FindCityById
        [Fact]
        public async Task IsFindCityByIdReturnsCurrentCity()
        {
            //Arrange
            var list = await _currentCityService.GetAllCurrentCities();
            CurrentCity expectedCity = list.FirstOrDefault();


            //Act
            var result = await _currentCityService.GetCurrentCityById(expectedCity.CurrentCityId);

            // Assert
            var viewResult = Assert.IsType<CurrentCity>(result);
            var model = Assert.IsAssignableFrom<CurrentCity>(
                viewResult);
            Assert.Equal(expectedCity.Name, model.Name);
            Assert.Equal(expectedCity.Id, model.Id);
        }

        //Check AddCurrentCity
        [Fact]
        public async Task IsAddCityReturnsModelAndAddsCity()
        {
            //Arrange
            HttpClient client = new HttpClient();
            CurrentCity currentCity = new CurrentCity();
            string city = "London";
            HttpResponseMessage response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=acce9ab3f19ec245d1d1505a9b382711");

            if (response.IsSuccessStatusCode)
                currentCity = await response.Content.ReadAsAsync<CurrentCity>();

            //Act
            var result = await _currentCityService.CreateCurrentCity(currentCity);

            // Assert
            var viewResult = Assert.IsType<CurrentCity>(result);
            var model = Assert.IsAssignableFrom<CurrentCity>(viewResult);
            Assert.NotNull(model.Name);
            Assert.Equal(currentCity.Id, model.Id);
        }

        //Check UpdateSkill
        [Fact]
        public async Task IsUpdateCityReturnsNewModel()
        {
            //Arrange
            var list = await _currentCityService.GetAllCurrentCities();
            var city = list.ToList().FirstOrDefault();
            var previousName = city.Name;
            city.Name = "UnitTest";

            //Act
            _currentCityService.UpdateCurrentCity(city);
            var result = list.ToList().FirstOrDefault();

            // Assert
            var viewResult = Assert.IsType<CurrentCity>(result);
            var model = Assert.IsAssignableFrom<CurrentCity>(viewResult);
            Assert.NotNull(model.Name);
            Assert.NotEqual(model.Name, previousName);
        }


        //Check DeleteSkill
        [Fact]
        public async Task IsDeleteCityRemovesModel()
        {
            //Arrange
            var list = await _currentCityService.GetAllCurrentCities();
            var city = list.ToList().FirstOrDefault();
            var id = city.CurrentCityId;

            //Act
            var result = _currentCityService.DeleteCurrentCity(id);

            // Assert
            var viewResult = Assert.IsType<bool>(result);
            var model = Assert.IsAssignableFrom<bool>(viewResult);
            Assert.True(model);
        }
    }
}
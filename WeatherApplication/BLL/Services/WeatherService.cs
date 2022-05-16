using BLL.IServices;
using DAL.UOW;
using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IUnitOfWork unitOfWork;

        public WeatherService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Weather> CreateWeather(Weather weather)
        {
            Weather newWeather = await unitOfWork.Weather.CreateAsync(weather);
            unitOfWork.Save();
            return newWeather;
        }

        public void DeleteWeather(Guid id)
        {
            unitOfWork.Weather.Delete(id);
            unitOfWork.Save();
        }

        public async Task<IEnumerable<Weather>> GetAllWeathers()
        {
            return await unitOfWork.Weather.GetAllAsync();
        }

        public async Task<Weather> GetWeatherById(Guid id)
        {
            return await unitOfWork.Weather.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Weather>> GetWeathersByConditions(Expression<Func<Weather, bool>> expression)
        {
            return await unitOfWork.Weather.FindByConditionAsync(expression);
        }

        public void UpdateWeather(Weather weather)
        {
            unitOfWork.Weather.Update(weather);
            unitOfWork.Save();
        }
    }
}

using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.IServices
{
    public interface IWeatherService
    {
        Task<IEnumerable<Weather>> GetAllWeathers();

        Task<Weather> GetWeatherById(Guid id);

        Task<IEnumerable<Weather>> GetWeathersByConditions(Expression<Func<Weather, bool>> expression);

        void DeleteWeather(Guid id);

        void UpdateWeather(Weather weather);

        Task<Weather> CreateWeather(Weather weather);
    }
}

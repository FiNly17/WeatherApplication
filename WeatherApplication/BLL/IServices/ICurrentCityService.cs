using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.IServices
{
    public interface ICurrentCityService
    {
        Task<IEnumerable<CurrentCity>> GetAllCurrentCities();

        Task<CurrentCity> GetCurrentCityById(Guid id);

        Task<IEnumerable<CurrentCity>> GetCurrentCitiesByConditions(Expression<Func<CurrentCity, bool>> expression);

        bool DeleteCurrentCity(Guid id);

        void UpdateCurrentCity(CurrentCity city);

        Task<CurrentCity> CreateCurrentCity(CurrentCity city);
    }
}

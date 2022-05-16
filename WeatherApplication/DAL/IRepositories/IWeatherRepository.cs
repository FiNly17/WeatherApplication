

using ObjectLayer;
using System.Linq.Expressions;

namespace DAL.IRepositories
{
    public interface IWeatherRepository
    {        
        Task<IEnumerable<Weather>> GetAllAsync();
        Task<IEnumerable<Weather>> FindByConditionAsync(Expression<Func<Weather, bool>> expression);
        Task<Weather> FindByIdAsync(Guid id);

        Task<Weather> CreateAsync(Weather item);

        void Update(Weather item);
        void Delete(Guid id);
    }
}

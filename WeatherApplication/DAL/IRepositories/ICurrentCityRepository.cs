using ObjectLayer;
using System.Linq.Expressions;

namespace DAL.IRepositories
{
    public interface ICurrentCityRepository
    {
        Task<IEnumerable<CurrentCity>> GetAllAsync();
        Task<IEnumerable<CurrentCity>> FindByConditionAsync(Expression<Func<CurrentCity, bool>> expression);
        Task<CurrentCity> FindByIdAsync(Guid id);

        Task<CurrentCity> CreateAsync(CurrentCity item);

        void Update(CurrentCity item);
        void Delete(Guid id);
    }
}

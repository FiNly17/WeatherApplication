using ObjectLayer;
using System.Linq.Expressions;

namespace DAL.IRepositories
{
    public interface ICloudsRepository
    {
        Task<IEnumerable<Clouds>> GetAllAsync();
        Task<IEnumerable<Clouds>> FindByConditionAsync(Expression<Func<Clouds, bool>> expression);
        Task<Clouds> FindByIdAsync(Guid id);

        Task<Clouds> CreateAsync(Clouds item);

        void Update(Clouds item);
        void Delete(Guid id);
    }
}

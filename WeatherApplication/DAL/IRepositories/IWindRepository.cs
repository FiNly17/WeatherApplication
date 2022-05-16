using ObjectLayer;
using System.Linq.Expressions;

namespace DAL.IRepositories
{
    public interface IWindRepository
    {
        Task<IEnumerable<Wind>> GetAllAsync();
        Task<IEnumerable<Wind>> FindByConditionAsync(Expression<Func<Wind, bool>> expression);
        Task<Wind> FindByIdAsync(Guid id);

        Task<Wind> CreateAsync(Wind item);

        void Update(Wind item);
        void Delete(Guid id);
    }
}

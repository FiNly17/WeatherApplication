using ObjectLayer;
using System.Linq.Expressions;

namespace DAL.IRepositories
{
    public interface ISysRepository
    {
        Task<IEnumerable<Sys>> GetAllAsync();
        Task<IEnumerable<Sys>> FindByConditionAsync(Expression<Func<Sys, bool>> expression);
        Task<Sys> FindByIdAsync(Guid id);

        Task<Sys> CreateAsync(Sys item);

        void Update(Sys item);
        void Delete(Guid id);
    }
}

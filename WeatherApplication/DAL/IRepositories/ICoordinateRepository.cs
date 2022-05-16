using ObjectLayer;
using System.Linq.Expressions;

namespace DAL.IRepositories
{
    public interface ICoordinateRepository
    {
        Task<IEnumerable<Coordinate>> GetAllAsync();
        Task<IEnumerable<Coordinate>> FindByConditionAsync(Expression<Func<Coordinate, bool>> expression);
        Task<Coordinate> FindByIdAsync(Guid id);

        Task<Coordinate> CreateAsync(Coordinate item);

        void Update(Coordinate item);
        void Delete(Guid id);
    }
}

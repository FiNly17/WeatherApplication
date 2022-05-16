using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.IServices
{
    public interface ICoordinateService
    {
        Task<IEnumerable<Coordinate>> GetAllCoordinates();

        Task<Coordinate> GetCoordinateById(Guid id);

        Task<IEnumerable<Coordinate>> GetCoordinatesByConditions(Expression<Func<Coordinate, bool>> expression);

        void DeleteCoordinate(Guid id);

        void UpdateCoordinate(Coordinate coordinate);

        Task<Coordinate> CreateCoordinate(Coordinate coordinate);
    }
}

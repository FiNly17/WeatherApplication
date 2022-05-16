using BLL.IServices;
using DAL.UOW;
using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class CoordinateService : ICoordinateService
    {
        private readonly IUnitOfWork unitOfWork;

        public CoordinateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Coordinate> CreateCoordinate(Coordinate coordinate)
        {
            Coordinate newCoordinate = await unitOfWork.Coordinates.CreateAsync(coordinate);
            unitOfWork.Save();
            return newCoordinate;
        }

        public void DeleteCoordinate(Guid id)
        {
            unitOfWork.Coordinates.Delete(id);
            unitOfWork.Save();
        }

        public async Task<IEnumerable<Coordinate>> GetAllCoordinates()
        {
            return await unitOfWork.Coordinates.GetAllAsync();
        }

        public async Task<Coordinate> GetCoordinateById(Guid id)
        {
            return await unitOfWork.Coordinates.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Coordinate>> GetCoordinatesByConditions(Expression<Func<Coordinate, bool>> expression)
        {
            return await unitOfWork.Coordinates.FindByConditionAsync(expression);
        }

        public void UpdateCoordinate(Coordinate coordinate)
        {
            unitOfWork.Coordinates.Update(coordinate);
            unitOfWork.Save();
        }
    }
}

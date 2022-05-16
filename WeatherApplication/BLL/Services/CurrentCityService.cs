using BLL.IServices;
using DAL.UOW;
using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class CurrentCityService : ICurrentCityService
    {
        private readonly IUnitOfWork unitOfWork;

        public CurrentCityService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<CurrentCity> CreateCurrentCity(CurrentCity city)
        {
            CurrentCity currentCity = await unitOfWork.Cities.CreateAsync(city);
            unitOfWork.Save();
            return currentCity;
        }

        public bool DeleteCurrentCity(Guid id)
        {
            try
            {
                unitOfWork.Cities.Delete(id);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<CurrentCity>> GetAllCurrentCities()
        {
            return await unitOfWork.Cities.GetAllAsync();
        }

        public async Task<IEnumerable<CurrentCity>> GetCurrentCitiesByConditions(Expression<Func<CurrentCity, bool>> expression)
        {
            return await unitOfWork.Cities.FindByConditionAsync(expression);
        }

        public async Task<CurrentCity> GetCurrentCityById(Guid id)
        {
            return await unitOfWork.Cities.FindByIdAsync(id);
        }

        public void UpdateCurrentCity(CurrentCity city)
        {
            unitOfWork.Cities.Update(city);
            unitOfWork.Save();
        }
    }
}

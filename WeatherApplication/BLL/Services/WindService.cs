using BLL.IServices;
using DAL.UOW;
using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class WindService : IWindService
    {
        private readonly IUnitOfWork unitOfWork;

        public WindService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Wind> CreateWind(Wind wind)
        {
            Wind newWind = await unitOfWork.Wind.CreateAsync(wind);
            unitOfWork.Save();
            return newWind;
        }

        public void DeleteWind(Guid id)
        {
            unitOfWork.Wind.Delete(id);
            unitOfWork.Save();
        }

        public async Task<IEnumerable<Wind>> GetAllWinds()
        {
            return await unitOfWork.Wind.GetAllAsync();
        }

        public async Task<Wind> GetWindById(Guid id)
        {
            return await unitOfWork.Wind.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Wind>> GetWindsByConditions(Expression<Func<Wind, bool>> expression)
        {
            return await unitOfWork.Wind.FindByConditionAsync(expression);
        }

        public void UpdateWind(Wind wind)
        {
            unitOfWork.Wind.Update(wind);
            unitOfWork.Save();
        }
    }
}

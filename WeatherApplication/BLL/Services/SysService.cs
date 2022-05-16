using BLL.IServices;
using DAL.UOW;
using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class SysService : ISysService
    {
        private readonly IUnitOfWork unitOfWork;

        public SysService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Sys> CreateSys(Sys sys)
        {
            Sys newSys = await unitOfWork.Sys.CreateAsync(sys);
            unitOfWork.Save();
            return newSys;
        }

        public void DeleteSys(Guid id)
        {
            unitOfWork.Sys.Delete(id);
            unitOfWork.Save();
        }

        public async Task<IEnumerable<Sys>> GetAllSys()
        {
            return await unitOfWork.Sys.GetAllAsync();
        }

        public async Task<IEnumerable<Sys>> GetSysByConditions(Expression<Func<Sys, bool>> expression)
        {
            return await unitOfWork.Sys.FindByConditionAsync(expression);
        }

        public async Task<Sys> GetSysById(Guid id)
        {
            return await unitOfWork.Sys.FindByIdAsync(id);
        }

        public void UpdateSys(Sys sys)
        {
            unitOfWork.Sys.Update(sys);
            unitOfWork.Save();
        }
    }
}

using BLL.IServices;
using DAL.UOW;
using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class MainInformationService : IMainInformationService
    {
        private readonly IUnitOfWork unitOfWork;

        public MainInformationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<MainInformation> CreateMainInformation(MainInformation main)
        {
            MainInformation mainInformation = await unitOfWork.Main.CreateAsync(main);
            unitOfWork.Save();
            return mainInformation;
        }

        public void DeleteMainInformation(Guid id)
        {
            unitOfWork.Main.Delete(id);
            unitOfWork.Save();
        }

        public async Task<IEnumerable<MainInformation>> GetAllMainInformations()
        {
            return await unitOfWork.Main.GetAllAsync();
        }

        public async Task<MainInformation> GetMainInformationById(Guid id)
        {
            return await unitOfWork.Main.FindByIdAsync(id);
        }

        public async Task<IEnumerable<MainInformation>> GetMainInformationsByConditions(Expression<Func<MainInformation, bool>> expression)
        {
            return await unitOfWork.Main.FindByConditionAsync(expression);
        }

        public void UpdateMainInformation(MainInformation main)
        {
            unitOfWork.Main.Update(main);
            unitOfWork.Save();
        }
    }
}

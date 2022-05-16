using BLL.IServices;
using DAL.UOW;
using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class CloudsService : ICloudsService
    {
        private readonly IUnitOfWork unitOfWork;

        public CloudsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Clouds> CreateCloud(Clouds cloud)
        {
            Clouds clouds = await unitOfWork.Clouds.CreateAsync(cloud);
            unitOfWork.Save();
            return clouds;
        }

        public bool DeleteCloud(Guid id)
        {
            try
            {
                unitOfWork.Clouds.Delete(id); 
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Clouds>> GetAllClouds()
        {
            return await unitOfWork.Clouds.GetAllAsync();
        }

        public async Task<Clouds> GetCloudById(Guid id)
        {
            return await unitOfWork.Clouds.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Clouds>> GetCloudsByConditions(Expression<Func<Clouds, bool>> expression)
        {
            return await unitOfWork.Clouds.FindByConditionAsync(expression);
        }

        public void UpdateCloud(Clouds cloud)
        {
            unitOfWork.Clouds.Update(cloud);
            unitOfWork.Save();
        }
    }
}

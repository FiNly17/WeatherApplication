using ObjectLayer;
using System.Linq.Expressions;

namespace DAL.IRepositories
{
    public interface IMainInformationRepository
    {
        Task<IEnumerable<MainInformation>> GetAllAsync();
        Task<IEnumerable<MainInformation>> FindByConditionAsync(Expression<Func<MainInformation, bool>> expression);
        Task<MainInformation> FindByIdAsync(Guid id);

        Task<MainInformation> CreateAsync(MainInformation item);

        void Update(MainInformation item);
        void Delete(Guid id);
    }
}

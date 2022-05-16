using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.IServices
{
    public interface IMainInformationService
    {
        Task<IEnumerable<MainInformation>> GetAllMainInformations();

        Task<MainInformation> GetMainInformationById(Guid id);

        Task<IEnumerable<MainInformation>> GetMainInformationsByConditions(Expression<Func<MainInformation, bool>> expression);

        void DeleteMainInformation(Guid id);

        void UpdateMainInformation(MainInformation main);

        Task<MainInformation> CreateMainInformation(MainInformation main);
    }
}

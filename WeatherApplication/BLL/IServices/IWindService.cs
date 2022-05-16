using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.IServices
{
    public interface IWindService
    {
        Task<IEnumerable<Wind>> GetAllWinds();

        Task<Wind> GetWindById(Guid id);

        Task<IEnumerable<Wind>> GetWindsByConditions(Expression<Func<Wind, bool>> expression);

        void DeleteWind(Guid id);

        void UpdateWind(Wind wind);

        Task<Wind> CreateWind(Wind wind);
    }
}

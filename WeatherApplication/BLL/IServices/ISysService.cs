using ObjectLayer;
using System.Linq.Expressions;

namespace BLL.IServices
{
    public interface ISysService
    {
        Task<IEnumerable<Sys>> GetAllSys();

        Task<Sys> GetSysById(Guid id);

        Task<IEnumerable<Sys>> GetSysByConditions(Expression<Func<Sys, bool>> expression);

        void DeleteSys(Guid id);

        void UpdateSys(Sys wind);

        Task<Sys> CreateSys(Sys wind);
    }
}

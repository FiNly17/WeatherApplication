using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface ICloudsService
    {
        Task<IEnumerable<Clouds>> GetAllClouds();

        Task<Clouds> GetCloudById(Guid id);

        Task<IEnumerable<Clouds>> GetCloudsByConditions(Expression<Func<Clouds, bool>> expression);

        bool DeleteCloud(Guid id);

        void UpdateCloud(Clouds cloud);

        Task<Clouds> CreateCloud(Clouds cloud);
    }
}

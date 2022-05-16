using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    public interface IUnitOfWork
    {
        ICloudsRepository Clouds { get; }
        ICoordinateRepository Coordinates { get; }
        ICurrentCityRepository Cities { get; }
        IMainInformationRepository Main { get; }
        ISysRepository Sys { get; }
        IWeatherRepository Weather { get; }
        IWindRepository Wind { get; }

        public void Save();
    }
}

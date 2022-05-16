using DAL.IRepositories;
using DAL.Repositories;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly WeatherContext context;

        private ICloudsRepository clouds;
        private ICoordinateRepository coordinate;
        private ICurrentCityRepository currentCity;
        private IMainInformationRepository mainInformation;
        private ISysRepository sys;
        private IWeatherRepository weather;
        private IWindRepository wind;

        public UnitOfWork(WeatherContext context)
        {
            this.context = context;
        }

        public ICloudsRepository Clouds
        {
            get
            {
                if (clouds == null)
                    clouds = new CloudsRepository(context);

                return clouds;
            }
        }

        public ICoordinateRepository Coordinates
        {
            get
            {
                if(coordinate == null)
                    coordinate = new CoordinateRepository(context);

                return coordinate;
            }
        }

        public ICurrentCityRepository Cities
        {
            get
            {
                if (currentCity == null)
                    currentCity = new CurrentCityRepository(context);

                return currentCity;
            }
        }

        public IMainInformationRepository Main
        {
            get
            {
                if (mainInformation == null)
                    mainInformation = new MainInformationRepository(context);

                return mainInformation;
            }
        }

        public ISysRepository Sys
        {
            get
            {
                if(sys == null)
                    sys = new SysRepository(context);

                return sys;
            }
        }

        public IWindRepository Wind
        {
            get
            {
                if(wind == null)
                    wind = new WindRepository(context);

                return wind;
            }
        }

        public IWeatherRepository Weather
        {
            get
            {
                if(weather == null)
                    weather = new WeatherRepository(context);

                return weather;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                context.DisposeAsync();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

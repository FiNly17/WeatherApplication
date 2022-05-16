using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLayer
{
    public class WeatherContext : DbContext
    {
        public DbSet<Clouds> Clouds { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<CurrentCity> CurrentCities { get; set; }
        public DbSet<MainInformation> MainInformation { get; set; }
        public DbSet<Sys> Sys { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Wind> Winds { get; set; }

        public WeatherContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Weather;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}

using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using ObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly WeatherContext context;
        protected readonly DbSet<T> set;

        protected Repository(WeatherContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public virtual async Task<T> CreateAsync(T item)
        {
            var entityEntry = await set.AddAsync(item);
            return entityEntry.Entity;
        }

        public virtual void Delete(Guid id)
        {
            T del_item = set.Find(id);
            if (del_item != null)
            {
                set.Remove(del_item);
            }
        }

        public virtual async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await set.Where(expression).ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(Guid id)
        {
            return await set.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await set.ToListAsync();
        }

        public void Update(T item)
        {
            context.Update(item);
        }
    }
}

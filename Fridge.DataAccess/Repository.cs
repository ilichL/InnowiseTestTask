using Fridge.Core.Interfaces.Data;
using Fridge.Data.Entities;
using Fridsge.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fridge.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity 
    {
        private readonly Context context;
        private readonly DbSet<T> dbSet;

        public Repository (Context context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual async Task Add(T obj)
        {
            await dbSet.AddAsync(obj);
        }

        public virtual async Task AddRange(IQueryable<T> objs)
        {
            await dbSet.AddRangeAsync(objs);
        }

        public virtual async Task<T> FindById(Guid id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(obj => obj.Id.Equals(id));
        }

        public virtual async Task Remove(Guid id)
        {
            dbSet.Remove(await FindById(id));
        }

        public virtual async Task Update(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual IQueryable<T> Get()
        {
            return dbSet;
        }


    }
}

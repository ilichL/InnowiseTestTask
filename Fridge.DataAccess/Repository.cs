using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data;
using FridgeWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FridgeWarehouse.DataAccess
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

        public virtual async Task AddAsync(T obj)
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

        public virtual async Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes)
        {
            var result = dbSet.Where(predicate);

            if (includes.Any())
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }
            return result;
        }

        public virtual IQueryable<T> Get()
        {
            return dbSet;
        }


    }
}

using FridgeWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.Interfaces.Data
{
    public interface IRepository <T> where T : BaseEntity
    {
        Task AddAsync(T obj);
        Task AddRange(IQueryable<T> objs);
        Task<T> FindById(Guid id);
        Task Remove(Guid id);
        Task Update(T obj);
        IQueryable<T> Get();
        Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes);

    }
}

using Fridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fridge.Core.Interfaces.Data
{
    public interface IRepository <T> where T : BaseEntity
    {
        Task Add(T obj);
        Task AddRange(IQueryable<T> objs);
        Task<T> FindById(Guid id);
        Task Remove(Guid id);
        Task Update(T obj);
        IQueryable<T> Get();

    }
}

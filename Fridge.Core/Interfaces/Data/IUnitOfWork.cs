using FridgeWarehouse.Data.Entities;
using FridgeWarehouse.Data;
using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        IRepository<Fridge> Fridges { get; }
        IRepository<FridgeModel> FridgeModels { get; }
        IRepository<FridgeProduct> FridgeProducts { get; }
        IRepository<Product> Products { get; }

        Task<int> SaveChanges();
    }
}

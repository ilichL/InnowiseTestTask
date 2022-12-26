using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data;
using FridgeWarehouse.Data.Entities;
using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context context;
        private readonly IRepository<Fridge> fridgeRepository;
        private readonly IRepository<FridgeModel> fridgeModelRepository;
        private readonly IRepository<FridgeProduct> fridgeProductRepository;
        private readonly IRepository<Product> productRepository;

        public UnitOfWork(Context context, IRepository<FridgeProduct> fridgeProductRepository, IRepository<Product> productRepository,
            IRepository<Fridge> fridgeRepository, IRepository<FridgeModel> fridgeModelRepository)
        {
            this.context = context;
            this.fridgeProductRepository = fridgeProductRepository;
            this.productRepository = productRepository;
            this.fridgeRepository = fridgeRepository;
            this.fridgeModelRepository = fridgeModelRepository;
        }

        public IRepository<Fridge> Fridges => fridgeRepository;
        public IRepository<FridgeModel> FridgeModels => fridgeModelRepository;
        public IRepository<FridgeProduct> FridgeProducts => fridgeProductRepository;
        public IRepository<Product> Products => productRepository;

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

    }
}

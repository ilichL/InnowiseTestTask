using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Core.Interfaces;
using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FridgeWarehouse.Domain.Interfaces
{
    public class FridgeProductService : IFridgeProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public FridgeProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<FridgeProduct> GetAllFridgeProducts()
        {
            return unitOfWork.FridgeProducts.Get();
        }

        public async Task<FridgeProductDTO> GetFridgeProductsByFridgeIdAsync(Guid id)//fridge id
        {
            return mapper.Map<FridgeProductDTO>(await unitOfWork.FridgeProducts.FindBy(fridgeProduct
               => fridgeProduct.FridgeId.Equals(id)));
        }

        public async Task AddFridgeProduct(FridgeProductDTO model)
        {
            var fridgeProduct = mapper.Map<FridgeProduct>(model);
            fridgeProduct.Id = Guid.NewGuid();

            await unitOfWork.FridgeProducts.AddAsync(fridgeProduct);
            await unitOfWork.SaveChanges();
        }

        public async Task RemoveFridgeProduct(FridgeProductDTO model, FridgeDTO fridgeModel)
        {
            var product = await GetFridgeWithProducts(model, fridgeModel);

            await unitOfWork.FridgeProducts.Remove(product.Id);
            await unitOfWork.SaveChanges();
        }

        private async Task<FridgeProduct> GetFridgeWithProducts(FridgeProductDTO model, FridgeDTO fridgeModel)
        {
            return await unitOfWork.Fridges.Get()
             .Where(fridge => fridge.Name.Equals(fridgeModel.Name) && fridge.LocationAddress.Equals(fridgeModel.LocationAddress)    )
             .Include(fridge => fridge.FridgeProducts)
             .ThenInclude(fridgeProducts => fridgeProducts.Product).AsNoTracking()
             .SelectMany(fridge => fridge.FridgeProducts)
             .Where(product => product.Product.Name.Equals(model.Name) && product.Quantity.Equals(model.Quantity)).FirstOrDefaultAsync();
        }

        public async Task UpdateFridgeProduct(FridgeProductDTO model, FridgeDTO fridgeModel, int quantity)
        {
            FridgeProduct product = await GetFridgeWithProducts(model, fridgeModel);
            product.Quantity = quantity;

            await unitOfWork.FridgeProducts.Update(product);
            await unitOfWork.SaveChanges();
        }
    }
}

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
    public class FridgeProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IFridgeService fridgeService;
        //FridgeProducts
        public FridgeProductService(IUnitOfWork unitOfWork, IMapper mapper, IFridgeService fridgeService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.fridgeService = fridgeService;
        }

        public IEnumerable<FridgeProduct> GetAllFridgeProductsProduts()
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

        public async Task RemoveFridgeProduct(FridgeProductDTO model)
        {
            var fridgeProduct = await(await unitOfWork.FridgeProducts.FindBy(fridgeProduct => fridgeProduct.Name.Equals(model.Name),
                fridgeProducts => fridgeProducts.Quantity.Equals(model.Quantity))).FirstOrDefaultAsync();
            await unitOfWork.FridgeProducts.Remove(fridgeProduct.Id);
            //delete fridgeProduct from Fridge?
        }
    }
}

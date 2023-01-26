using FridgeWarehouse.Core.DTOs;
using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.Interfaces
{
    public interface IFridgeProductService
    {
        IEnumerable<FridgeProduct> GetAllFridgeProducts();
        Task<FridgeProductDTO> GetFridgeProductsByFridgeIdAsync(Guid id);
        Task AddFridgeProduct(FridgeProductDTO model);
        Task RemoveFridgeProduct(FridgeProductDTO model, FridgeDTO fridgeModel);
        Task UpdateFridgeProductAsync(FridgeProductDTO model, FridgeDTO fridgeModel, int quantity);
        Task UpdateFridgeProductByIdAsync(Guid id, FridgeProductDTO model);
        Task RemoveFridgeProductByTdAsync(Guid id);
        List<FridgeProductDTO> GetFridgeProductsByFridgeId(Guid fridgeId);
    }
}

using FridgeWarehouse.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.Interfaces
{
    public interface IFridgeProductService
    {
        Task<FridgeProductDTO> GetFridgeProductsByFridgeIdAsync(Guid id);
        Task AddFridgeProduct(FridgeProductDTO model);
        Task RemoveFridgeProduct(FridgeProductDTO model, FridgeDTO fridgeModel);
        Task UpdateFridgeProduct(FridgeProductDTO model, FridgeDTO fridgeModel, int quantity);
    }
}

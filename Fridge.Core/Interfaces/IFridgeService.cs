using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.Interfaces
{
    public interface IFridgeService
    {
        IEnumerable<Fridge> GetAllFridges();

        Task AddFridgeAsync(FridgeDTO model);

        Task UpdateFridgeAsync(FridgeDTO model, FridgeModelDTO fridgeModel, string? name, string? locationAddress);

        Task RemoveFridgeByIdAsync(Guid id);
        Task RemoveFridgeAsync(FridgeDTO model, FridgeModelDTO fridgeModel);

        Task<FridgeDTO> GetFridgeByIdASync(Guid id);
        Task<FridgeDTO> GetFridgeAsync(FridgeDTO model, FridgeModelDTO fridgeModel);

    }
}

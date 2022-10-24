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

        Task AddFridgeAsync(Fridge model);

        Task UpdateFridge(Fridge model);

        Task RemoveFridge(Fridge model);

        Task<FridgeDTO> GetFridgeByIdASync(Guid id);

    }
}

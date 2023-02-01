using FridgeWarehouse.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.Interfaces.Data
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByFRidgeProductIdAsync(Guid id);
    }
}

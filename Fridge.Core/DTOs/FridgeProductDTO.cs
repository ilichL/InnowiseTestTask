using FridgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.DTOs
{
    public class FridgeProductDTO : BaseDTO
    {
        public int Quantity { get; set; }
        public virtual ProductDTO Product { get; set; }
        public virtual FridgeDTO Fridge { get; set; }
    }
}

using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }    
        public FridgeProductDTO FridgeProduct { get; set; }
    }
}

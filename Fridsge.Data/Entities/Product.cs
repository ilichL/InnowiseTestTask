using FridgeWarehouse.Data.Entities;
using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
        public virtual FridgeProduct FridgeProduct { get; set; }

    }
}

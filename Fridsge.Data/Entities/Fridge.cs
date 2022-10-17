using FridgeWarehouse.Data.Entities;
using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Data.Entities
{
    public class Fridge : BaseEntity
    {
        public string Name { get; set; }
        public Guid FridgeModelId { get; set; }
        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}

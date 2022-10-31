using FridgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridsgeWarehouse.Data.Entities
{
    public class FridgeProduct : BaseEntity
    {
        public int Quantity { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Fridge Fridge { get; set; }
    }
}

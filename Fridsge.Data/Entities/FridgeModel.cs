using FridgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridsgeWarehouse.Data.Entities
{
    public class FridgeModel : BaseEntity
    {
        public string Name { get; set; }
        public int year { get; set; }
        public virtual ICollection<Fridge> Fridges { get; set; }
    }
}

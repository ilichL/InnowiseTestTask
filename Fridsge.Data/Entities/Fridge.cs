using Fridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fridsge.Data.Entities
{
    public class Fridge : BaseEntity
    {
        public string Name { get; set; }
        public Guid FRidgeModelId { get; set; }
        public virtual ICollection<FridgeProduct> FridgeProducts { get; set; }
    }
}

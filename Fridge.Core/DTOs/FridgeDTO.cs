using FridsgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.DTOs
{
    public class FridgeDTO : BaseDTO
    {
        public string Name { get; set; }
        public string LocationAddress { get; set; }
        public Guid? FridgeModelId { get; set; }
        public virtual ICollection<FridgeDTO>? FridgeProducts { get; set; }
    }
}

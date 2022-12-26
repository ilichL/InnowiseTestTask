using FridgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Core.DTOs
{
    public class FridgeModelDTO : BaseDTO
    {
        public int year { get; set; }
        public FridgeDTO Fridge { get; set; }
    }
}

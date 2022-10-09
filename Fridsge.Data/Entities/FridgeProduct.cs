using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fridsge.Data.Entities
{
    public class FridgeProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Guid FRidgeId { get; set; }
        public Guid ProductId { get; set; }
    }
}

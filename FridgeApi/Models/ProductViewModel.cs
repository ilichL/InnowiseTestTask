using FridsgeWarehouse.Data.Entities;

namespace FridgeWarehouseApi.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
        public virtual FridgeProductViewModel FridgeProduct { get; set; }
    }
}

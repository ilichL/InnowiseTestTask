using FridgeWarehouse.Data.Entities;

namespace FridgeWarehouseApi.Models
{
    public class FridgeProductViewModel
    {
        public int Quantity { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public virtual FridgeViewModel Fridge { get; set; }
    }
}

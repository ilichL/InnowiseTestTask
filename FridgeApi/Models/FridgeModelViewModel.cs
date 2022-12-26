using FridgeWarehouse.Data.Entities;

namespace FridgeWarehouseApi.Models
{
    public class FridgeModelViewModel
    {
        public string? Name { get; set; }
        public int year { get; set; }
        public virtual FridgeViewModel Fridge { get; set; }
    }
}

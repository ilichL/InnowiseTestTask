using FridsgeWarehouse.Data.Entities;

namespace FridgeWarehouseApi.Models
{
    public class FridgeViewModel
    {
        public string Name { get; set; }
        public string LocationAddress { get; set; }
        public virtual FridgeModelViewModel? FridgeModel { get; set; }
        public virtual ICollection<FridgeProductViewModel>? FridgeProducts { get; set; }
    }
}

using FridsgeWarehouse.Data.Entities;

namespace FridgeWarehouseApi.Models.ModelsWithId
{
    public class FridgeViewModelWithId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int year { get; set; }
        public virtual FridgeViewModel Fridge { get; set; }
    }
}

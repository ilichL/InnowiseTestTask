namespace FridgeWarehouseApi.Models.ModelsWithId
{
    public class FridgeProductViewModelWithId
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public virtual FridgeViewModel Fridge { get; set; }
    }
}

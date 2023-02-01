using FridgeWarehouse.Core.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;

namespace FridgeWarehouseApi.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet(nameof(GetProductByFridgeProductId))]
        public async Task<IActionResult> GetProductByFridgeProductId(Guid id)
        {
            var result = await productService.GetProductByFRidgeProductIdAsync(id);

            return Ok(result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

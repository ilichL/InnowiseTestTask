using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouseApi.Models;
using FridgeWarehouseApi.Models.ModelsWithId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeWarehouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly IFridgeProductService fridgeProductService;
        private readonly IMapper mapper;

        public FridgeProductController(IFridgeProductService fridgeProductService, IMapper mapper)
        {
            this.fridgeProductService = fridgeProductService;
            this.mapper = mapper;
        }   

        [HttpGet(nameof(GetFridgeProductCollection))]
        public IActionResult GetFridgeProductCollection()
        {
            return Ok(fridgeProductService.GetAllFridgeProducts());
        }

        [HttpPost(nameof(AddFridgeProduct))]
        public async Task<IActionResult> AddFridgeProduct(FridgeProductViewModel model)
        {
            await fridgeProductService.AddFridgeProduct(mapper.Map<FridgeProductDTO>(model));
            return Ok(model);
        }

        [HttpGet(nameof(RemoveFridgeProduct))]
        public async Task<IActionResult> RemoveFridgeProduct(FridgeProductViewModelWithId model)
        {
            await fridgeProductService.RemoveFridgeProductByTdAsync(model.Id);
            return Ok();
        }

        [HttpPost(nameof(UpdateFridgeProduct))]
        public async Task<IActionResult> UpdateFridgeProduct(FridgeProductViewModelWithId model)
        {
            await fridgeProductService.UpdateFridgeProductByIdAsync(model.Id, mapper.Map<FridgeProductDTO>(model));
            return Ok();
        }

        [HttpGet(nameof(GetFridgeProductsByFridgeId))]
        public IActionResult GetFridgeProductsByFridgeId(Guid id)
        {
            return Ok(fridgeProductService.GetFridgeProductsByFridgeId(id));
        }

    }
}

using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data;
using FridgeWarehouse.Data.Entities;
using FridgeWarehouseApi.Models;
using FridgeWarehouseApi.Models.ModelsWithId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeWarehouseApi.Controllers
{//https://localhost:7225/api/Fridge/GetFRidges/6f9619ff-8b86-d011-b42d-00c05fc964fc
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeService fridgeService;
        private readonly IFridgeProductService fridgeProductService;
        private readonly IMapper mapper;
        private readonly ILogger<FridgeController> logger;

        public FridgeController(IFridgeService fridgeService,IMapper mapper, IFridgeProductService fridgeProductService,
            ILogger<FridgeController> logger)
        {
            this.fridgeService = fridgeService;
            this.mapper = mapper;
            this.fridgeProductService = fridgeProductService;
            this.logger = logger;
        }

        [HttpGet(nameof(GetFridgeCollection))]
        public IActionResult GetFridgeCollection()
        {//Errror 400
         try
         {
            return Ok(fridgeService.GetAllFridges());
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
            
        }

        [HttpPost(nameof(AddFridge))]
        public async Task<IActionResult> AddFridge(FridgeViewModel model)
        {
            try
            {
                await fridgeService.AddFridgeAsync(mapper.Map<FridgeDTO>(model));
                return Ok();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }

        }

        [HttpPost(nameof(EditFridge))]
        public async Task<IActionResult> EditFridge(FridgeViewModelWithId model)
        {
            try
            {
                await fridgeService.EditFridge(mapper.Map<FridgeDTO>(model), model.Id);
                return Ok();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }

        }
        

        [HttpPost(nameof(RemoveFridge))]
        public async Task<IActionResult> RemoveFridgeById(Guid id)
        {
            try
            {
                //remove products
                var fridge = await fridgeService.GetFridgeByIdASync(id);
                //await fridgeProductService.RemoveFridgeProductByTd(fridge.)
                await fridgeService.RemoveFridgeByIdAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpGet(nameof(GetFridgeById))]
        public async Task<IActionResult> GetFridgeById(Guid id)
        {//6f9619ff-8b86-d011-b42d-00c05fc964fc
            try
            {
                var fridge = await fridgeService.GetFridgeByIdASync(id);
                return Ok(fridge);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }

        }

        [HttpGet(nameof(GetFridge))]
        public async Task<IActionResult> GetFridge(FridgeViewModel model)
        {
            try
            {
                return Ok(await fridgeService.GetFridgeAsync(mapper.Map<FridgeDTO>(model),
                    mapper.Map<FridgeModelDTO>(model.FridgeModel)));
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            } 
        }

        [HttpGet(nameof(RemoveFridge))]
        public async Task<IActionResult> RemoveFridge(FridgeViewModel model)
        {
            try
            {
                await fridgeService.RemoveFridgeAsync(mapper.Map<FridgeDTO>(model),
                    mapper.Map<FridgeModelDTO>(model.FridgeModel));
                return Ok();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }
    }
}

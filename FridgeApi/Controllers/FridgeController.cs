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
/*
 * 1)Как запускать контроллеры api
 * 2) GET-забор POST-изменение
 * 3) 2 одинаковых метода в контроллере пример в гит MVC
 * 4)SQL правильная ли диаграмма 
 * 5) вопрос по условию в SQL 
 */


namespace FridgeWarehouseApi.Controllers
{//https://localhost:7225/api/Fridge/GetFRidges/6f9619ff-8b86-d011-b42d-00c05fc964fc
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Context context;
        private readonly IFridgeService fridgeService;
        private readonly IMapper mapper;

        public FridgeController(IUnitOfWork unitOfWork, Context context, IFridgeService fridgeService, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
            this.fridgeService = fridgeService;
            this.mapper = mapper;
        }

        [HttpGet(nameof(Test))]
        public async Task<IActionResult> Test ()
        {
            Fridge test = new Fridge()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                FridgeModelId = Guid.NewGuid(),
            };
            await context.Fridges.AddAsync(test);
            await context.SaveChangesAsync();
            //await unitOfWork.Fridges.Add(test);
            //await unitOfWork.SaveChanges();
            return new BadRequestResult();
        }

        [HttpGet(nameof(GetFridgeCollection))]
        public IActionResult GetFridgeCollection()
        {
            return Ok(mapper.Map<FridgeModelViewModel>(fridgeService.GetAllFridges()));
        }

        [HttpPost(nameof(AddFridge))]
        public async Task<IActionResult> AddFridge(FridgeViewModel model)
        {
            await fridgeService.AddFridgeAsync(mapper.Map<FridgeDTO>(model));
            return Ok();
        }
        public async Task<IActionResult> EditFridge(FridgeDTO model)
        {
            await fridgeService.GetFridgeAsync(model, )
        }
        [HttpPost(nameof(RemoveFridge))]
        public async Task<IActionResult> RemoveFridgeById(Guid id)
        {
            await fridgeService.RemoveFridgeByIdAsync(id);
            return Ok();
        }

        [HttpGet(nameof(GetFridgeById))]
        public async Task<IActionResult> GetFridgeById(Guid id)
        {//6f9619ff-8b86-d011-b42d-00c05fc964fc
            var fridge = await fridgeService.GetFridgeByIdASync(id);
            return Ok();
        }

        [HttpGet(nameof(GetFridge))]
        public async Task<IActionResult> GetFridge(FridgeViewModel model)
        {
            return Ok(await fridgeService.GetFridgeAsync(mapper.Map<FridgeDTO>(model),
            mapper.Map<FridgeModelDTO>(model.FridgeModel)));  
        }

        [HttpPost(nameof(RemoveFridge))]
        public async Task<IActionResult> RemoveFridge(FridgeViewModel model)
        {
            await fridgeService.RemoveFridgeAsync(mapper.Map<FridgeDTO>(model),
                mapper.Map<FridgeModelDTO>(model.FridgeModel));
            return Ok();
        }
    }
}

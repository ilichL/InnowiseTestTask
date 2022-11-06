using AutoMapper;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data;
using FridgeWarehouse.Data.Entities;
using FridgeWarehouseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgeWarehouseApi.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> Test ()
        {
            Fridge test = new Fridge()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                FridgeModelId = Guid.NewGuid(),
            };
            //await context.Fridges.AddAsync(test);
            //await context.SaveChangesAsync();
            //await unitOfWork.Fridges.Add(test);
            //await unitOfWork.SaveChanges();
            return new BadRequestResult();
        }

        public async Task<IActionResult> GetFridgeCollection()
        {
            return Ok(mapper.Map<FridgeModelViewModel>(fridgeService.GetAllFridges()));
        }
    }
}

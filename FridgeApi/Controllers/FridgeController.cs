using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data;
using FridgeWarehouse.Data.Entities;
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
        public FridgeController(IUnitOfWork unitOfWork, Context context)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
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
    }
}

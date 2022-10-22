using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data;
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

        [HttpPost]
        public async Task Test ()
        {
            unitOfWork.friges
        }
    }
}

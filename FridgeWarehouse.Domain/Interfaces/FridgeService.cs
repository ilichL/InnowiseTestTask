using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Domain.Interfaces
{
    public class FridgeService : IFridgeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FridgeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        public IEnumerable<Fridge> GetAllFridges()
        {
            return unitOfWork.Fridges.Get();
        }

        public async Task AddFridgeAsync(Fridge model)
        {
            await unitOfWork.Fridges.AddAsync(model);
            await unitOfWork.SaveChanges();
        }

        public async Task UpdateFridge(Fridge model)
        {
            await unitOfWork.Fridges.Update(model);
            await unitOfWork.SaveChanges();
        }

        public async Task RemoveFridge(Fridge model)
        {
            await unitOfWork.Fridges.Remove(model.Id);
            await unitOfWork.SaveChanges();
        }

        public async Task<FridgeDTO> GetFridgeByIdASync(Guid id)
        {
            return mapper.Map<FridgeDTO>(await unitOfWork.Fridges.FindById(id));
        }

    }
}

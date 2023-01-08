using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouse.Core.Interfaces.Data;
using FridgeWarehouse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<FridgeService> logger;

        public FridgeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FridgeService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }
        
        public FridgeDTO GetAllFridges()
        {
            try
            {
                return mapper.Map<FridgeDTO>(unitOfWork.Fridges.Get().FirstOrDefault());
               
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        
        }

        public async Task AddFridgeAsync(FridgeDTO model)
        {
            var fridge = mapper.Map<Fridge>(model);
            fridge.Id = Guid.NewGuid();
            await unitOfWork.Fridges.AddAsync(fridge);
            await unitOfWork.SaveChanges();
        }

        public async Task UpdateFridgeAsync(FridgeDTO model, FridgeModelDTO fridgeModel, string? name, string? locationAddress)
        {
            var fridge = await GetFridgeWithFridgeModel(model, fridgeModel);

            if(name != null)
                fridge.Name = name;
            if(locationAddress != null)
                fridge.LocationAddress = locationAddress;

            await unitOfWork.Fridges.Update(fridge);
            await unitOfWork.SaveChanges();
        }

        public async Task EditFridge(FridgeDTO model, Guid id)
        {
            var fridge = await unitOfWork.Fridges.FindById(id);
            fridge = mapper.Map<Fridge>(model);
            await unitOfWork.Fridges.Update(fridge);
        }

        public async Task RemoveFridgeByIdAsync(Guid id)
        {
            await unitOfWork.Fridges.Remove(id);
            await unitOfWork.SaveChanges();
        }

        public async Task<FridgeDTO> GetFridgeByIdASync(Guid id)
        {
            return mapper.Map<FridgeDTO>(await unitOfWork.Fridges.FindById(id));
        }

        public async Task<FridgeDTO> GetFridgeAsync(FridgeDTO model, FridgeModelDTO fridgeModel)
        {
            return mapper.Map<FridgeDTO>(await GetFridgeWithFridgeModel(model, fridgeModel));
        }

        private async Task<Fridge> GetFridgeWithFridgeModel(FridgeDTO model, FridgeModelDTO fridgeModel)
        {
            return await unitOfWork.Fridges.Get()
            .Where(fridge => fridge.Name.Equals(model.Name) && fridge.LocationAddress.Equals(model.LocationAddress))
            .Include(fridge => fridge.FridgeModel.Name.Equals(fridgeModel.Name) && fridge.FridgeModel.year.Equals(fridgeModel.year))
            .FirstOrDefaultAsync();
        }

        public async Task RemoveFridgeAsync(FridgeDTO model, FridgeModelDTO fridgeModel)
        {
            var fridge = await GetFridgeWithFridgeModel(model, fridgeModel);

            await unitOfWork.Fridges.Remove(fridge.Id);
            await unitOfWork.SaveChanges();
        }

    }
}

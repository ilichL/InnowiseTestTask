using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridsgeWarehouse.Data.Entities;

namespace FridgeWarehouseApi.Mapper
{
    public class FridgeModelProfile : Profile
    {
        public FridgeModelProfile()
        {
            CreateMap<FridgeModel, FridgeModelDTO>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Id))
                .ForMember(dto => dto.year,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.year))
                .ForMember(dto => dto.Fridge,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Fridges))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Name));

            CreateMap<FridgeModelDTO, FridgeModel>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Id))
                .ForMember(dto => dto.year,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.year))
                .ForMember(dto => dto.Fridges,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Fridge))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(fridgeModel => fridgeModel.Name));
        }
    }
}

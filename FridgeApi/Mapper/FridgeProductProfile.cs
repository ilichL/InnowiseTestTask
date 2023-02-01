using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridsgeWarehouse.Data.Entities;

namespace FridgeWarehouse.Mvc.Mapper
{
    public class FridgeProductProfile : Profile
    {
        public FridgeProductProfile()
        {
            CreateMap<FridgeProduct, FridgeProductDTO>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(productModel => productModel.Id))
                .ForMember(dto => dto.Quantity,
                    opt => opt.MapFrom(productModel => productModel.Quantity))
                .ForMember(dto => dto.Product,
                    opt => opt.MapFrom(producttModel => producttModel.Product))
                .ForMember(dto => dto.Fridge,
                    opt => opt.MapFrom(productModel => productModel.Fridge));

            CreateMap<FridgeProductDTO, FridgeProduct>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(productModel => productModel.Id))
                .ForMember(dto => dto.Quantity,
                    opt => opt.MapFrom(productModel => productModel.Quantity))
                .ForMember(dto => dto.Product,
                    opt => opt.MapFrom(producttModel => producttModel.Product))
                .ForMember(dto => dto.Fridge,
                    opt => opt.MapFrom(productModel => productModel.Fridge));
        }


    }
}

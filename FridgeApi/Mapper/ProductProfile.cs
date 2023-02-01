using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Data.Entities;

namespace FridgeWarehouseApi.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(dto => dto.DefaultQuantity,
                    opt => opt.MapFrom(product => product.DefaultQuantity));

            CreateMap<ProductDTO, Product>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(dto => dto.DefaultQuantity,
                    opt => opt.MapFrom(product => product.DefaultQuantity));
        }
    }
}

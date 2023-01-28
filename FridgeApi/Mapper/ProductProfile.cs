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
                .ForMember(dto => dto.Name,
                opt => opt.MapFrom(product => product.Name));

            CreateMap<ProductDTO, Product>()
                .ForMember(dto => dto.Name,
                opt => opt.MapFrom(product => product.Name));
        }
    }
}

using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeWarehouse.Domain.Interfaces
{
    public class ProductService : IProductService 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ProductDTO> GetProductByFRidgeProductIdAsync(Guid id)
        {
            return mapper.Map<ProductDTO>(await unitOfWork.Products.Get()
                .Include(x => x.FridgeProduct)
                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync());
            
        }
    }
}

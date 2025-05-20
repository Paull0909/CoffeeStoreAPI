using Application.IRepositoty;
using Application.Service;
using AutoMapper;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositoty
{
    class ProductSizesRepository : RepositoryBase<ProductSizes, int>,IProductSizesRepository
    {
        private readonly IMapper _mapper;

        public ProductSizesRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ProductSizes>> GetByProduct(int id)
        {
            var size = await _context.ProductSizes.Where(t => t.ProductID == id).ToListAsync();
            return size;
        }
    }
}

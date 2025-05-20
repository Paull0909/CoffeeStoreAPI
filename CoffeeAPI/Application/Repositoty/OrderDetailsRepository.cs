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
    class OrderDetailsRepository : RepositoryBase<OrderDetails, int>,IOrderDetailsRepository
    {
        private readonly IMapper _mapper;

        public OrderDetailsRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<OrderDetails>> GetByOrderID(int id)
        {
            var detail = await _context.OrderDetails.Where(t => t.OrderID == id).ToListAsync();
            return detail;
        }
    }
}

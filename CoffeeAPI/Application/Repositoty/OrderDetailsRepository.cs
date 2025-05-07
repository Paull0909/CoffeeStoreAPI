using Application.IRepositoty;
using Application.Service;
using AutoMapper;
using Data.Context;
using Data.Entities;
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
    }
}

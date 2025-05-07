using Application.Service;
using AutoMapper;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositoty
{
    class ToppingsRepository : RepositoryBase<Toppings, int>,IToppingsRepository
    {
        private readonly IMapper _mapper;

        public ToppingsRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}

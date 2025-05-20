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
    class SuppliersRepository : RepositoryBase<Suppliers, int>,ISuppliersRepository
    {
        private readonly IMapper _mapper;

        public SuppliersRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public bool FindName(string name)
        {

            var cate = _context.Suppliers.Where(t => t.SupplierName == name).ToList();
            if (cate != null) return true;
            else return false;
        }
    }
}

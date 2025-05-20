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
    class MaterialsRepository : RepositoryBase<Materials, int>,IMaterialsRepository
    {
        private readonly IMapper _mapper;

        public MaterialsRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public bool FindName(string name)
        {
            var mate = _context.Materials.Where(t => t.MaterialName == name).ToList();
            if (mate != null) return true;
            else return false;
        }

        public async Task<List<Materials>> GetByCategory(int id)
        {
            var mate = await _context.Materials.Where(t => t.CategoryID == id).ToListAsync();
            return mate;
        }
    }
}

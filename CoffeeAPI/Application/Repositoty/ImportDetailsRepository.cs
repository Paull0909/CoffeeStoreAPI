using Application.IRepositoty;
using Application.Service;
using AutoMapper;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositoty
{
    class ImportDetailsRepository : RepositoryBase<ImportDetails, int>,IImportDetailsRepository
    {
        private readonly IMapper _mapper;

        public ImportDetailsRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ImportDetails>> GetByImportReceipt(int id)
        {
            var ip = await _context.ImportDetails.Where(t => t.ImportID == id).ToListAsync();
            return ip;
        }
    }
}

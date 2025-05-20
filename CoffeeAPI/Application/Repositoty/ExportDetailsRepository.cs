using Application.IRepositoty;
using Application.Service;
using AutoMapper;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositoty
{
    class ExportDetailsRepository : RepositoryBase<ExportDetails, int>,IExportDetailsRepository
    {
        private readonly IMapper _mapper;

        public ExportDetailsRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ExportDetails>> GetByExportReceipt(int id)
        {
            var exd = await _context.ExportDetails.Where(t => t.ExportID == id).ToListAsync();
            return exd;
        }
    }
}

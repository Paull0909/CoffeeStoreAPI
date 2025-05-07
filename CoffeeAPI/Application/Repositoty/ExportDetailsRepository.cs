using Application.IRepositoty;
using Application.Service;
using AutoMapper;
using Data.Context;
using Data.Entities;

namespace Application.Repositoty
{
    class ExportDetailsRepository : RepositoryBase<ExportDetails, int>,IExportDetailsRepository
    {
        private readonly IMapper _mapper;

        public ExportDetailsRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}

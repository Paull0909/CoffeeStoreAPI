using Application.IRepositoty;
using Application.Service;
using AutoMapper;
using Data.Context;
using Data.Entities;

namespace Application.Repositoty
{
    class ImportDetailsRepository : RepositoryBase<ImportDetails, int>,IImportDetailsRepository
    {
        private readonly IMapper _mapper;

        public ImportDetailsRepository(Web_Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}

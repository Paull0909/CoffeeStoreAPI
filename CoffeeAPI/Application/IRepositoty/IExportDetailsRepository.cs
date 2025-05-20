using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface IExportDetailsRepository : IRepository<ExportDetails, int>
    {
        Task<List<ExportDetails>> GetByExportReceipt(int id);
    }
}

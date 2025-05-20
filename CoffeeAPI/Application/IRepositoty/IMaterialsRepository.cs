using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface IMaterialsRepository : IRepository<Materials, int>
    {
        bool FindName(string name);
        Task<List<Materials>> GetByCategory(int id);
    }
}

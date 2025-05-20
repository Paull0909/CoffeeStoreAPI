using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface ISuppliersRepository : IRepository<Suppliers, int>
    {
        bool FindName(string name);
    }
}

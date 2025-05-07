using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface IPaymentsRepository : IRepository<Payments, int>
    {
    }
}

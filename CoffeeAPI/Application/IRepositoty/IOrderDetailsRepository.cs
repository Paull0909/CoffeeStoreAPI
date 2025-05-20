using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails, int>
    {
        Task<List<OrderDetails>> GetByOrderID(int id);
    }
}

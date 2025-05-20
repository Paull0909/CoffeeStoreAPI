using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface IOrdersRepository : IRepository<Orders, int>
    {
    }
}

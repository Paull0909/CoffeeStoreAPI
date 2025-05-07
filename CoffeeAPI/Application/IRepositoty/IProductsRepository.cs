using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface IProductsRepository : IRepository<Products, int>
    {
    }
}

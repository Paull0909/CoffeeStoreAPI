using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface IProductSizesRepository : IRepository<ProductSizes, int>
    {
        Task<List<ProductSizes>> GetByProduct(int id);
    }
}

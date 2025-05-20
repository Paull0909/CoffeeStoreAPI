using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface ICategories_ProductsRepository : IRepository<Categories_Products, int>
    {
        bool FindName(string name);
    }
}

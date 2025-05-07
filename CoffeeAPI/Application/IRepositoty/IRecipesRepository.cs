using Application.SeedWorks;
using Data.Entities;

namespace Application.IRepositoty
{
    public interface IRecipesRepository : IRepository<Recipes, int>
    {
    }
}

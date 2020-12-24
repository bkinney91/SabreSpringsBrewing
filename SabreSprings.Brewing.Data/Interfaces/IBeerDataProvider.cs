using SabreSprings.Brewing.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IBeerDataProvider
    {
        Task<Beer> GetBeer(int id);
        Task Add(Beer beer);
        Task Update(Beer beer);
        Task<List<Beer>> GetBeers();
        Task<Beer> GetBeerFromRecipe(int recipeId);
    }
}

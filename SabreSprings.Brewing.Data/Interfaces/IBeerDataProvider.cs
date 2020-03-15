using SabreSprings.Brewing.Models.Entities;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IBeerDataProvider
    {
        Task<Beer> GetBeer(int id);
        Task<Beer> GetBeerFromRecipe(int recipeId);
    }
}

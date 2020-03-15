using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IRecipeDataProvider
    {
        Task<Recipe> GetRecipe(int id);
        Task<List<RecipeMaterialDto>> GetRecipeMaterials(int recipeId);
        Task<List<RecipeHeaderDto>> GetRecipeHeaders();
        
    }
}

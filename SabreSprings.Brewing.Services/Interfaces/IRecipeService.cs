using SabreSprings.Brewing.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> GetRecipe(int id);
        Task<List<RecipeHeaderDto>> GetRecipeHeaders();
        Task AddRecipe(RecipeDto dto);
        Task UpdateRecipe(RecipeDto dto);
    }
}

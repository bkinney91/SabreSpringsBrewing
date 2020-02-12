using SabreSprings.Brewing.Data;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeDataProvider RecipeDataProvider;
        public RecipeService(IRecipeDataProvider recipeDataProvider)
        {
            RecipeDataProvider = recipeDataProvider;
        }

        public async Task<RecipeDto> GetRecipe(int id)
        {
            RecipeDto recipeDto = new RecipeDto();
            Recipe recipe = await RecipeDataProvider.GetRecipe(id);
            recipeDto.Materials = await GetRecipeMaterials(id);

            return recipeDto;
        }

        public async Task<List<RecipeMaterialDto>> GetRecipeMaterials(int id)
        {
            List <RecipeMaterialDto> GetRecipeMaterials = new List<RecipeMaterialDto>();
        }
    }
}

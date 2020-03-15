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

        /// <summary>
        /// Gets a DTO of the recipe based on the id passed in.
        /// Retrieves all recipe materials as well.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RecipeDto> GetRecipe(int id)
        {            
            Recipe recipe = await RecipeDataProvider.GetRecipe(id);
            RecipeDto recipeDto = new RecipeDto()
            {
                Materials = await GetRecipeMaterials(id),
                Id = recipe.Id,
                Name = recipe.Name,
                Yeast = recipe.Yeast,
                PitchTemperature = recipe.PitchTemperature,
                FermentationTemperatureLow = recipe.FermentationTemperatureLow,
                FermentationTemperatureHigh = recipe.FermentationTemperatureHigh,
                StrikeWaterVolume = recipe.StrikeWaterVolume,
                StrikeWaterTemperature = recipe.StrikeWaterTemperature,
                MashTemperature = recipe.MashTemperature,
                MashInstructions = recipe.MashInstructions,
                DaysInPrimaryFermentation = recipe.DaysInPrimaryFermentation,
                DaysInSecondaryFermentation = recipe.DaysInSecondaryFermentation,
                PreBoilGravity = recipe.PreBoilGravity,
                OriginalGravity = recipe.OriginalGravity,
                FinalGravity = recipe.FinalGravity,
                ABV = recipe.ABV,
                IBU = recipe.IBU,
                SRM = recipe.SRM,
                MashPh = recipe.MashPh,
                BrewingNotes = recipe.BrewingNotes,
                FermentationNotes = recipe.FermentationNotes,
                Created = recipe.Created,
                CreatedBy = recipe.CreatedBy
            };            
            return recipeDto;
        }

        public async Task<List<RecipeHeaderDto>> GetRecipeHeaders()
        {
            return await RecipeDataProvider.GetRecipeHeaders();
        }

        /// <summary>
        /// Retrieves all of the recipe materials for a recipe.
        /// Note: is called by GetRecipe, and recipe materials 
        /// are in the DTO for Recipe.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public async Task<List<RecipeMaterialDto>> GetRecipeMaterials(int recipeId)
        {            
            return await RecipeDataProvider.GetRecipeMaterials(recipeId);            
        }
    }
}

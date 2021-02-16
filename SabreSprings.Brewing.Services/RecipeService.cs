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
        private readonly IBeerDataProvider BeerDataProvider;
        public RecipeService(IRecipeDataProvider recipeDataProvider, IBeerDataProvider beerDataProvider)
        {
            RecipeDataProvider = recipeDataProvider;
            BeerDataProvider = beerDataProvider;
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
            Beer beer = await BeerDataProvider.GetBeerFromRecipe(id);
            RecipeDto recipeDto = new RecipeDto()
            {
                //Materials = await GetRecipeMaterials(id),
                Id = recipe.Id,
                Name = beer.Name,
                Style = beer.Style,
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
                Created = recipe.Created
            };            
            return recipeDto;
        }

        public async Task AddRecipe(RecipeDto dto)
        {
            Recipe entity = new Recipe()
            {
                Yeast = dto.Yeast,
                PitchTemperature = dto.PitchTemperature,
                FermentationTemperatureLow = dto.FermentationTemperatureLow,
                FermentationTemperatureHigh = dto.FermentationTemperatureHigh,
                StrikeWaterVolume = dto.StrikeWaterVolume,
                StrikeWaterTemperature = dto.StrikeWaterTemperature,
                MashTemperature = dto.MashTemperature,
                MashInstructions = dto.MashInstructions,
                DaysInPrimaryFermentation = dto.DaysInPrimaryFermentation,
                DaysInSecondaryFermentation = dto.DaysInSecondaryFermentation,
                PreBoilGravity = dto.PreBoilGravity,
                OriginalGravity = dto.OriginalGravity,
                FinalGravity = dto.FinalGravity,
                ABV = dto.ABV,
                IBU = dto.IBU,
                SRM = dto.SRM,
                MashPh = dto.MashPh,
                BrewingNotes = dto.BrewingNotes,
                FermentationNotes = dto.FermentationNotes,
                Created = dto.Created
            };
            await RecipeDataProvider.Add(entity);
        }

        public async Task UpdateRecipe(RecipeDto dto)
        {
            Recipe entity = new Recipe()
            {
                Id = dto.Id,
                Yeast = dto.Yeast,
                PitchTemperature = dto.PitchTemperature,
                FermentationTemperatureLow = dto.FermentationTemperatureLow,
                FermentationTemperatureHigh = dto.FermentationTemperatureHigh,
                StrikeWaterVolume = dto.StrikeWaterVolume,
                StrikeWaterTemperature = dto.StrikeWaterTemperature,
                MashTemperature = dto.MashTemperature,
                MashInstructions = dto.MashInstructions,
                DaysInPrimaryFermentation = dto.DaysInPrimaryFermentation,
                DaysInSecondaryFermentation = dto.DaysInSecondaryFermentation,
                PreBoilGravity = dto.PreBoilGravity,
                OriginalGravity = dto.OriginalGravity,
                FinalGravity = dto.FinalGravity,
                ABV = dto.ABV,
                IBU = dto.IBU,
                SRM = dto.SRM,
                MashPh = dto.MashPh,
                BrewingNotes = dto.BrewingNotes,
                FermentationNotes = dto.FermentationNotes,
                Created = dto.Created
            };
            await RecipeDataProvider.Update(entity);
        }

        public async Task<List<RecipeHeaderDto>> GetRecipeHeaders()
        {
            return await RecipeDataProvider.GetRecipeHeaders();
        }

        
    }
}

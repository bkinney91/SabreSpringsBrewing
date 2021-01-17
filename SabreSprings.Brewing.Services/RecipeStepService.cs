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
    public class RecipeStepService : IRecipeMaterialService
    {
        private readonly IRecipeStepDataProvider RecipeStepDataProvider;
        public RecipeStepService(IRecipeStepDataProvider recipeStepDataProvider)
        {
            RecipeStepDataProvider = recipeStepDataProvider;
        }

        public async Task<RecipeStepDto> GetRecipeStep(int id)
        {
            RecipeStep entity = await RecipeStepDataProvider.GetRecipeStep(id);
            RecipeStepDto dto = new RecipeStepDto()
            {
                Recipe = entity.Recipe,
                Stage = entity.Stage,
                StepNumber = entity.StepNumber,
                DisplayText = entity.DisplayText,
                TimerMinutes = entity.TimerMinutes,
                Created = entity.Created
            };
            return dto;
        }

        public async Task Add(RecipeStepDto dto)
        {
            RecipeStep entity = new RecipeStep()
            {
                Recipe = dto.Recipe,
                Stage = dto.Stage,
                StepNumber = dto.StepNumber,
                DisplayText = dto.DisplayText,
                TimerMinutes = dto.TimerMinutes,
                Created = dto.Created
            };
            await RecipeStepDataProvider.Add(entity);
        }

        public async Task Update(RecipeStepDto dto)
        {
            RecipeStep entity = new RecipeStep()
            {
                Id = dto.Id,
                Recipe = dto.Recipe,
                Stage = dto.Stage,
                StepNumber = dto.StepNumber,
                DisplayText = dto.DisplayText,
                TimerMinutes = dto.TimerMinutes,
            };
            await RecipeStepDataProvider.Update(entity);
        }

        public async Task<List<RecipeStepDto>> GetRecipeSteps(int recipe)
        {
            List<RecipeStepDto> dtos = new List<RecipeStepDto>();
            List<RecipeStep> entities = await RecipeStepDataProvider.GetRecipeSteps(recipe);
            foreach (RecipeStep entity in entities)
            {
                RecipeStepDto dto = new RecipeStepDto()
                {
                    Recipe = entity.Recipe,
                    Stage = entity.Stage,
                    StepNumber = entity.StepNumber,
                    DisplayText = entity.DisplayText,
                    TimerMinutes = entity.TimerMinutes,
                    Created = entity.Created
                };
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}

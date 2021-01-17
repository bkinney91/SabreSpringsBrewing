using SabreSprings.Brewing.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IRecipeStepService
    {
        Task<RecipeStepDto> GetRecipeStep(int id);
        Task Add(RecipeStepDto dto);
        Task Update(RecipeStepDto dto);
        Task<List<RecipeStepDto>> GetRecipeSteps(int recipe);
    }
}

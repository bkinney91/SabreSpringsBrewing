using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SabreSprings.Brewing.Models.Entities;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IRecipeStepDataProvider
    {
        Task<RecipeStep> GetRecipeStep(int id);
        Task Add(RecipeStep step);
        Task Update(Recipe recipe);
        Task<List<RecipeStep>> GetRecipeSteps(int recipe);
       
    }
}

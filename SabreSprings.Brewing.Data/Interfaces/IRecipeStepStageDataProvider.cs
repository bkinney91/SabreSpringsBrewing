using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SabreSprings.Brewing.Models.Entities;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IRecipeStepStageDataProvider
    {
        Task<RecipeStepStage> GetRecipeStepStage(int id);
        Task<List<RecipeStepStage>> GetRecipeStepStages();
       
    }
}

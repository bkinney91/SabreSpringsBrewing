using SabreSprings.Brewing.Data;
using SabreSprings.Brewing.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Services
{
    public class RecipeService
    {
        private readonly IRecipeDataProvider RecipeDataProvider;
        public RecipeService(IRecipeDataProvider recipeDataProvider)
        {
            RecipeDataProvider = recipeDataProvider;
        }

        public RecipeDto GetRecipe(int id)
        {

        }
    }
}

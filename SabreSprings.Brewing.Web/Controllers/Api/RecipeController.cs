using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Services;
using SabreSprings.Brewing.Services.Interfaces;
using Serilog;

namespace SabreSprings.Brewing.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService RecipeService;
        private readonly ILogger Logger;
        public RecipeController(IRecipeService recipeService, ILogger logger)
        {
            RecipeService = recipeService;
            Logger = logger;
        }

        [HttpGet]
        [Route("GetRecipe")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            try
            {
                RecipeDto recipe = await RecipeService.GetRecipe(id);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error getting recipe with ID \"{id}\".");
                throw;
            }
        }
    }
}
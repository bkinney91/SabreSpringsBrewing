using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class RecipeDataProvider : IRecipeDataProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public RecipeDataProvider(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<Recipe> GetRecipe(int id)
        {
            Recipe recipe;
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select " +
                            "Id, " +
                            "Name, " + 
                            "Yeast, " + 
                            "PitchTemperature, " +
                            "FermentationTemperatureLow, " + 
                            "FermentationTemperatureHigh, " +
                            "CAST(StrikeWaterVolume AS REAL) as StrikeWaterVolume, " +
                            "StrikeWaterTemperature, " + 
                            "MashTemperature, " +
                            "MashInstructions, " +
                            "DaysInPrimaryFermentation, " + 
                            "DaysInSecondaryFermentation, " +
                            "CAST(PreBoilGravity as REAL) as PreBoilGravity, " +
                            "CAST(OriginalGravity as REAL) as OriginalGravity, " +
                            "CAST(FinalGravity as REAL) as FinalGravity, " +
                            "CAST(ABV as REAL) as ABV, " +
                            "CAST(IBU as REAL) as IBU, " +
                            "CAST(SRM as REAL) as SRM, " +
                            "CAST(MashPh as REAL) as MashPh, " +
                            "BrewingNotes, " + 
                            "FermentationNotes, " +
                            "Created, " +
                            "CreatedBy " +
                            " from Recipes where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                recipe = await db.QueryFirstAsync<Recipe>(sql, new { Id = id });                
            }
            return recipe;
        }


        public async Task<List<RecipeMaterialDto>> GetRecipeMaterials(int recipeId)
        {
            List<RecipeMaterialDto> recipeMaterials = new List<RecipeMaterialDto>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select " +
                            "r.Id, " +
                            "r.Recipe, " +
                            "r.Material, " +
                            "r.Quantity, " +
                            "m.Description as MaterialDescription, " +
                            "m.Attributes as MaterialAttributes, " +
                            "from RecipeMaterials r " +
                            "join Materials m on r.Material = m.Id " +
                            "where r.Recipe = @RecipeId;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<RecipeMaterialDto>(sql, new { RecipeId = recipeId });
                recipeMaterials = results.ToList();
            }
            return recipeMaterials;
        }
    }
}

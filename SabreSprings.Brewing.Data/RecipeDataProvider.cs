using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class RecipeDataProvider
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
                            "CAST(SRM as SRM) as SRM, " +
                            "CAST(MashPh as REAL) as MashPh, " +
                            "BrewingNotes, " + 
                            "FermentationNotes, " +
                            "Created, " +
                            "CreatedBy, " +
                            "from Recipe where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                recipe = await db.QueryFirstAsync<Recipe>(sql, new { Id = id });                
            }
            return recipe;
        }


        public async Task<List<RecipeMaterial>> GetRecipeMaterials(int recipeId)
        {
            List<RecipeMaterial> recipeMaterials = new List<RecipeMaterial>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select " +
                            "r.Id, " +
                            "r.Recipe, " +
                            "m.Material, " +
                            "r.Quantity, " +
                            "m.Description, " +
                            "m.Attribute, " +
                            "from RecipeMaterials r " +
                            "join Materials m on r.Material = m.Id " +
                            "where r.Recipe = @RecipeId;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<RecipeMaterial>(sql, new { RecipeId = recipeId });
                recipeMaterials = results.ToList();
            }
            return recipeMaterials;
        }
    }
}

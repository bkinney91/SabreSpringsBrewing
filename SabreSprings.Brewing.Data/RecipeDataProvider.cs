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
        public RecipeDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Recipe> GetRecipe(int id)
        {
            Recipe recipe;
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select " +
                            "Id, " +
                            "Yeast, " + 
                            "BoilTime, " +
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

        public async Task<Recipe> GetRecipeByBeer(int beer)
        {
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select ID from Recipes where Beer=@Beer;"; 
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var recipeId = await db.QueryFirstAsync<int>(sql);
                return await GetRecipe(recipeId);
            }
        }


        public async Task Add(Recipe recipe)
        {
            string sql = @"Insert into Recipes 
                            (Beer,
                            Yeast,
                            PitchTemperature,
                            BoilTime,
                            FermentationTemperatureLow,
                            FermentationTemperatureHigh,
                            StrikeWaterVolume,
                            StrikeWaterTemperature,
                            MashTemperature,
                            MashInstructions,
                            DaysInPrimaryFermentation,
                            DaysInSecondaryFermentation
                            PreBoilGravity,
                            OriginalGravity,
                            FinalGravity,
                            ABV,
                            IBU,
                            SRM,
                            MashPh,
                            BrewingNotes,
                            FermentationNotes,
                            Created)
                        VALUES 
                            (@Beer,
                            @Yeast,
                            @PitchTemperature,
                            @BoilTime,
                            @FermentationTemperatureLow,
                            @FermentationTemperatureHigh,
                            @StrikeWaterVolume,
                            @StrikeWaterTemperature,
                            @MashTemperature,
                            @MashInstructions,
                            @DaysInPrimaryFermentation,
                            @DaysInSecondaryFermentation
                            @PreBoilGravity,
                            @OriginalGravity,
                            @FinalGravity,
                            @ABV,
                            @IBU,
                            @SRM,
                            @MashPh,
                            @BrewingNotes,
                            @FermentationNotes,
                            @Created);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, recipe);
            }
        }


        public async Task Update(Recipe recipe)
        {
            string sql = @"Update Recipes Set
                            Yeast = @Yeast,
                            BoilTime = @BoilTime,
                            PitchTemperature = @PitchTemperature,
                            FermentationTemperatureLow = @FermentationTemperatureLow,
                            FermentationTemperatureHigh = @FermentationTemperatureHigh,
                            StrikeWaterVolume = @StrikeWaterVolume,
                            StrikeWaterTemperature = @StrikeWaterTemperature,
                            MashTemperature = @MashTemperature,
                            MashInstructions = @MashInstructions,
                            DaysInPrimaryFermentation = @DaysInPrimaryFermentation,
                            DaysInSecondaryFermentation = @DaysInSecondaryFermentation,
                            PreBoilGravity = @PreBoilGravity,
                            OriginalGravity = @OriginalGravity,
                            FinalGravity = @FinalGravity,
                            ABV = @ABV,
                            IBU = @IBU,
                            SRM = @SRM,
                            MashPh = @MashPh,
                            BrewingNotes = @BrewingNotes,
                            FermentationNotes = @FermentationNotes
                            Where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, recipe);
            }
        }


        /// <summary>
        /// Gets a small amount of data related to a recipe 
        /// in order to display a large amount of recipes
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public async Task<List<RecipeHeaderDto>> GetRecipeHeaders()
        {
            List<RecipeHeaderDto> recipeHeaders = new List<RecipeHeaderDto>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select " +
                            "Name, " +
                            "Style, " +
                            "Recipe " +
                            "from Beers " +
                            "order by Style;";
                           
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<RecipeHeaderDto>(sql);
                recipeHeaders = results.ToList();
            }
            return recipeHeaders;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;

namespace SabreSprings.Brewing.Data
{
    public class RecipeStepStageDataProvider : IRecipeStepStageDataProvider
    {
        private readonly IConfiguration _configuration;
        public RecipeStepStageDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<RecipeStepStage> GetRecipeStepStage(int id)
        {
            RecipeStepStage stage = new RecipeStepStage();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from RecipeStepStage where Id = @Id;";
                         
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                stage = await db.QueryFirstAsync<RecipeStepStage>(sql, new { Id = id });                
            }
            return stage;
        }


        public async Task<List<RecipeStepStage>> GetRecipeStepStages()
        {
 
            List<RecipeStepStage> stages= new List<RecipeStepStage>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from RecipeStepStages;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<RecipeStepStage>(sql);
                stages = results.ToList();
            }
            return stages;
        
        }
    }
}

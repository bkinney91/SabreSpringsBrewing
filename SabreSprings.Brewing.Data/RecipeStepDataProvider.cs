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
    public class RecipeStepDataProvider : IRecipeStepDataProvider
    {
        private readonly IConfiguration _configuration;
        public RecipeStepDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<RecipeStep> GetRecipeStep(int id)
        {
            RecipeStep step = new RecipeStep();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from RecipeStep where Id = @Id;";
                         
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                step = await db.QueryFirstAsync<RecipeStep>(sql, new { Id = id });                
            }
            return step;
        }


        public async Task Add(RecipeStep step)
        {
            string sql = @"Insert into RecipeSteps 
                            (Recipe,
                            Stage,
                            Step,
                            StepNumber,
                            DisplayText,
                            TimerMinutes
                            Created)
                        VALUES 
                            (@Recipe,
                            @Stage,
                            @Step,
                            @StepNumber,
                            @DisplayText,
                            @TimerMinutes,
                            @Created);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, step);
            }
        }


        public async Task Update(Recipe recipe)
        {
            string sql = @"Update RecipeSteps Set                         
                            Recipe = @Recipe
                            Stage, = @Stage,
                            Step = @Step,
                            StepNumber = @StepNumber,
                            DisplayText = @DisplayText,
                            TimerMinutes = @TimerMinutes
                            Where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, recipe);
            }
        }

        public async Task<List<RecipeStep>> GetRecipeSteps(int recipe)
        {
 
            List<RecipeStep> steps = new List<RecipeStep>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from RecipeSteps where Recipe = @Recipe;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<RecipeStep>(sql, new { Recipe = recipe });
                steps = results.ToList();
            }
            return steps;
        
        }
    }
}

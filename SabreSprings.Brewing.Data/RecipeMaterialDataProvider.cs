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
    public class RecipeMaterialDataProvider : IRecipeMaterialDataProvider
    {
        private readonly IConfiguration _configuration;
        public RecipeMaterialDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<RecipeMaterial> GetRecipeMaterial(int id)
        {
            RecipeMaterial material = new RecipeMaterial();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from RecipeMaterial where Id = @Id;";
                         
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                material = await db.QueryFirstAsync<RecipeMaterial>(sql, new { Id = id });                
            }
            return material;
        }


        public async Task Add(RecipeMaterial material)
        {
            string sql = @"Insert into RecipeMaterial 
                            (Recipe,
                            Material,
                            Quantity,
                            Created)
                        VALUES 
                            (@Recipe,
                            @Material,
                            @Quantity,
                            @Created);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, material);
            }
        }


        public async Task Update(RecipeMaterial material)
        {
            string sql = @"Update RecipeMaterial Set                         
                            Quantity = @Quantity,
                            Material = @Material                           
                            Where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, material);
            }
        }

        public async Task<List<RecipeMaterial>> GetRecipeSteps(int recipe)
        {
 
            List<RecipeMaterial> materials = new List<RecipeMaterial>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from RecipeMaterial where Recipe = @Recipe;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<RecipeMaterial>(sql, new { Recipe = recipe });
                materials = results.ToList();
            }
            return materials;
        
        }
    }
}

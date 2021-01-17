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
    public class MaterialTypeDataProvider : IMaterialTypeDataProvider
    {
        private readonly IConfiguration _configuration;
        public MaterialTypeDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<MaterialType> GetMaterialType(int id)
        {
            MaterialType material = new MaterialType();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from RecipeMaterial where Id = @Id;";
                         
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                material = await db.QueryFirstAsync<MaterialType>(sql, new { Id = id });                
            }
            return material;
        }


      

        public async Task<List<MaterialType>> GetMaterialTypes()
        {
 
            List<MaterialType> materials = new List<MaterialType>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from RecipeMaterial where Recipe = @Recipe;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<MaterialType>(sql);
                materials = results.ToList();
            }
            return materials;
        
        }
    }
}

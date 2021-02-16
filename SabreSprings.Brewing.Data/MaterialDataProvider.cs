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
    public class MaterialDataProvider : IMaterialDataProvider
    {
        private readonly IConfiguration _configuration;
        public MaterialDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Material> GetMaterial(int id)
        {
            Material material;
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from Materials where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                material = await db.QueryFirstAsync<Material>(sql, new { Id = id });                
            }
            return material;
        }


        public async Task Add(Material material)
        {
            string sql = @"Insert into Materials 
                            (Type,
                            Description,
                            UnitOfMeasure,                            
                            Created)
                        VALUES 
                            (@Type,
                            @Description,
                            @UnitOfMeasure,
                            @Created);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, material);
            }
        }


        public async Task Update(Material material)
        {
            string sql = @"Update Materials Set
                            Description = @Description,
                            Type = @Type,
                            UnitOfMeasure = @UnitOfMeasure
                            Where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, material);
            }
        }


        public async Task<List<Material>> GetMaterialsByType(int type)
        {
            List<Material> materials = new List<Material>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from Materials where Type = @Type;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<Material>(sql, new { Type = type });
                materials = results.ToList();
            }
            return materials;
        }


        public async Task<List<Material>> GetAll()
        {
            List<Material> materials = new List<Material>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from Materials;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<Material>(sql);
                materials = results.ToList();
            }
            return materials;
        }


        public async Task<List<MaterialType>> GetMaterialTypes()
        {
            List<MaterialType> types = new List<MaterialType>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from MaterialTypes;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<MaterialType>(sql);
                types = results.ToList();
            }
            return types;
        }
        
    }
}

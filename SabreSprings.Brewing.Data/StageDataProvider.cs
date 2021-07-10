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
    public class StageDataProvider : IStageDataProvider
    {
        private readonly IConfiguration _configuration;
        public StageDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Stage> GetStage(int id)
        {
            Stage stage = new Stage();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from Stages where Id = @Id;";
                         
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                stage = await db.QueryFirstAsync<Stage>(sql, new { Id = id });                
            }
            return stage;
        }


        public async Task<List<Stage>> GetStages()
        {
 
            List<Stage> stages= new List<Stage>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = "Select * from Stages;";
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var results = await db.QueryAsync<Stage>(sql);
                stages = results.ToList();
            }
            return stages;
        
        }
    }
}

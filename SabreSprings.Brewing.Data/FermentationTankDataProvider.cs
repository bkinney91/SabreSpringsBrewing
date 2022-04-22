using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class FermentationTankDataProvider : IFermentationTankDataProvider
    {
        private readonly IConfiguration _configuration;
        public FermentationTankDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<FermentationTank> GetFermentationTank(int id)
        {
            FermentationTank tank = new FermentationTank();
            string sql = "Select * from FermentationTanks where Id= @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                tank = await db.QueryFirstAsync<FermentationTank>(sql, new { Id = id });
            }
            return tank;
        }


        public async Task<List<FermentationTank>> GetFermentationTanks()
        {
            List<FermentationTank> tanks = new List<FermentationTank>();
            string sql = "Select * from FermentationTanks";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                var result = await db.QueryAsync<FermentationTank>(sql);
                tanks = result.ToList();
            }
            return tanks;
        }
    }
}

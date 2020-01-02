using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Data;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class BeerDataProvider : IBeerDataProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public BeerDataProvider(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        public async Task<Beer> GetBeer(int id)
        {
            Beer beer = new Beer();
            string sql = "Select * from Beers where Id= @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                beer = await db.QueryFirstAsync<Beer>(sql, new { Id = id });
            }
            return beer;
        }
    }
}

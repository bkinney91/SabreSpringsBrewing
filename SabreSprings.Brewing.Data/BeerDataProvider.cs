using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Data;


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
        public Beer Get(int id)
        {
            Beer beer = new Beer();
            string sql = "Select * from Beers where Id= @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                beer = db.QueryFirst<Beer>(sql, new { Id = id });
            }
            return beer;
        }
    }
}

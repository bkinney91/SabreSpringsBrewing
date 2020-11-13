using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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

        public async Task<List<Beer>> GetBeers()
        {
            List<Beer> beer = new List<Beer>();
            string sql = "Select * from Beers";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                var result = await db.QueryAsync<Beer>(sql);
                beer = result.ToList();
            }
            return beer;
        }

        public async Task Add(Beer beer)
        {
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                string sql = @"Insert into Beer 
                                (Name, Style, Logo)
                                VALUES (@Name, @Style, @Logo);";
                await db.ExecuteAsync(sql, beer);
            }
        }

        public async Task Update(Beer beer)
        {
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                string sql = @"Update Beer set Name = @Name, Style = @Style, Logo = @Logo where Id = @Id";
                await db.ExecuteAsync(sql, beer);
            }
        }

        
    }
}

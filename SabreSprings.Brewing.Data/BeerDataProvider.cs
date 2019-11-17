using Dapper;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SabreSprings.Brewing.Data
{
    public class BeerDataProvider
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
            string sql = "Select * from Beer where Id= @Id;";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                beer = db.QueryFirst<Beer>(sql, new { Id = id });
            }
            return beer;
        }
    }
}

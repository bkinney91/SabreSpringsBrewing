using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using SabreSprings.Brewing.Data.Interfaces;
using System.Linq;

namespace SabreSprings.Brewing.Data
{
    public class BatchDataProvider : IBatchDataProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public BatchDataProvider(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public Batch Get(int id)
        {
            Batch batch = new Batch();
            string sql = "Select * from Batch where Id= @Id;";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                batch = db.QueryFirst<Batch>(sql, new { Id = id });
            }
            return batch;
        }

        public List<Batch> GetOnTap()
        {
            List<Batch> batchesOnTap = new List<Batch>();
            string sql = "Select * from Batch where Status = 'On Tap';";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                batchesOnTap = db.Query<Batch>(sql).ToList();
            }
            return batchesOnTap;
        }
    }
}

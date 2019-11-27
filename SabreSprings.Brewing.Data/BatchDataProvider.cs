using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Collections.Generic;
using System.Data;
using Dapper;
using SabreSprings.Brewing.Data.Interfaces;
using System.Linq;
using Microsoft.Data.Sqlite;

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
            string sql = "Select * from Batches where Id= @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                batch = db.QueryFirst<Batch>(sql, new { Id = id });
            }
            return batch;
        }

        public List<Batch> GetOnTap()
        {
            List<Batch> batchesOnTap = new List<Batch>();
            string sql = "Select * from Batches where Status = 'On Tap';";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                batchesOnTap = db.Query<Batch>(sql).ToList();
            }
            return batchesOnTap;
        }

        public void Add(Batch batch)
        {
            string sql = "Insert into Batches (Beer, BatchNumber, BatchName, Status, Substatus) VALUES (@Beer, @BatchNumber, @BatchName, @Status, @SubStatus);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                db.Execute(sql, batch);
            }
        }

        public List<Batch> GetAllBatches()
        {
            string sql = "Select * from Batches;";
            using(IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                List<Batch> batches = db.Query<Batch>(sql).ToList();
                return batches;
            }
        }
    }
}

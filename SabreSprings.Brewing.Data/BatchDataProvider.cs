using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Collections.Generic;
using System.Data;
using Dapper;
using SabreSprings.Brewing.Data.Interfaces;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

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

        public async Task<Batch> Get(int id)
        {
            Batch batch = new Batch();
            string sql = "Select * from Batches where Id= @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                batch = await db.QueryFirstAsync<Batch>(sql, new { Id = id });
            }
            return batch;
        }

        public async Task<List<Batch>> GetOnTap()
        {
            List<Batch> batchesOnTap = new List<Batch>();
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            string sql = @"Select 
                            Id,
                            Beer,
                            BatchNumber,
                            BatchName,
                            Status,
                            SubStatus,
                            Brewers,
                            Recipe,
                            Yeast,
                            CAST(PreBoilGravity as REAL) as PreBoilGravity,
                            CAST(OriginalGravity as REAL) as OriginalGravity,
                            CAST(FinalGravity as REAL) as FinalGravity,
                            CAST(ABV as REAL) as ABV,
                            CAST(PintsRemaining as REAL) as PintsRemaining,
                            DateBrewed,
                            DatePackaged,
                            DateTapped,
                            BrewingNotes,
                            TastingNotes,
                            Created,
                            CreatedBy
                            from Batches where Status = 'On Tap';";
            using (IDbConnection db = new SqliteConnection(connectionString)) 
            { 
                var taps = await db.QueryAsync<Batch>(sql);
                batchesOnTap = taps.ToList();
            }
            return batchesOnTap;
        }

        public async Task<int> GetBatchOnTap(int tapNumber)
        {
            string sql = "Select Id from Batches where Status = 'On Tap' and Substatus = @TapNumber;";
            string connectionString = _configuration.GetConnectionString("SabreSpringsBrewing");
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                return await db.ExecuteScalarAsync<int>(sql, new { TapNumber = tapNumber });
            }
        }

        public async Task Add(Batch batch)
        {
            string sql = @"Insert into Batches 
            (Beer, BatchNumber, BatchName, Status, Substatus)
            VALUES (@Beer, @BatchNumber, @BatchName, @Status, @SubStatus);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, batch);
            }
        }

        public async Task<List<Batch>> GetAllBatches()
        {
            string sql = @"Select  
                            Id,
                            Beer,
                            BatchNumber,
                            BatchName,
                            Status,
                            SubStatus,
                            Brewers,
                            Recipe,
                            Yeast,
                            CAST(PreBoilGravity as REAL) as PreBoilGravity,
                            CAST(OriginalGravity as REAL) as OriginalGravity,
                            CAST(FinalGravity as REAL) as FinalGravity,
                            CAST(ABV as REAL) as ABV,
                            CAST(PintsRemaining as REAL) as PintsRemaining,
                            DateBrewed,
                            DatePackaged,
                            DateTapped,
                            BrewingNotes,
                            TastingNotes,
                            Created,
                            CreatedBy from Batches;";
            using(IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                var batches = await db.QueryAsync<Batch>(sql);
                return batches.ToList();
            }
        }

        public async Task<Batch> GetBatch(int id)
        {
            string sql = @"Select  
                            Id,
                            Beer,
                            BatchNumber,
                            BatchName,
                            Status,
                            SubStatus,
                            Brewers,
                            Recipe,
                            Yeast,
                            CAST(PreBoilGravity as REAL) as PreBoilGravity,
                            CAST(OriginalGravity as REAL) as OriginalGravity,
                            CAST(FinalGravity as REAL) as FinalGravity,
                            CAST(ABV as REAL) as ABV,
                            CAST(PintsRemaining as REAL) as PintsRemaining,
                            DateBrewed,
                            DatePackaged,
                            DateTapped,
                            BrewingNotes,
                            TastingNotes,
                            Created,
                            CreatedBy from Batches
                            where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                var batch = await db.QueryFirstAsync<Batch>(sql, new { Id = id });
                return batch;
            }
        }


        public async Task SubtractPour(int batchId, decimal pour)
        {
            string sql = "Update Batches set PintsRemaining = PintsRemaining - @Pour where Id = @BatchId;";
            using(IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, new
                {
                    Pour = pour,
                    BatchId = batchId
                });
            }
        }

        public async Task<decimal> GetPintsRemaining(int batchId)
        {
            string sql = "Select PintsRemaining from Batches where Id = @BatchId;";
            using(IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                decimal pintsRemaining = await db.QueryFirstAsync<decimal>(sql, new { batchId });
                return pintsRemaining;
            }
        }
    }
}

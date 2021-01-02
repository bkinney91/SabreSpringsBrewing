using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class FermentabuoyDataProvider : IFermentabuoyDataProvider
    {

        private readonly IConfiguration _configuration;
        public FermentabuoyDataProvider(IConfiguration configuration
        {
            _configuration = configuration;
        }


        /// <summary>
        /// This method receives a Fermentabuoy entity from the service and inserts the data into the SQLite DB
        /// </summary>
        /// <param name="buoy"> The Entity that is received from the service</param>
        /// <returns></returns>
        public async Task AddFermentabuoy(Fermentabuoy buoy)
        {
            string sql = "Insert into Fermentabuoy (DeviceId, DeviceNumber, MacAddress, Created, CreatedBy) " +
                "VALUES (@DeviceId, @DeviceNumber, @MacAddress, @Created, @CreatedBy);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, buoy);
            }

        }

        /// <summary>
        /// Retrieves a Fermentabuoy entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Fermentabuoy> GetFermentabuoy(int id)
        {
            Fermentabuoy buoy = new Fermentabuoy();
            string sql = @"Select * from Fermentabuoy where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                buoy = await db.QueryFirstAsync<Fermentabuoy>(sql, new { Id = id });
            }
            return buoy;
        }


        /// <summary>
        /// Retrieves all Fermentabuoy entities from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Fermentabuoy>> GetAllFermentabuoys()
        {
            List<Fermentabuoy> buoys = new List<Fermentabuoy>();
            string sql = @"Select * from Fermentabuoy";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                buoys = await db.QueryFirstAsync<List<Fermentabuoy>>(sql);
            }
            return buoys;
        }


        /// <summary>
        /// This method receives a Fermentabuoy entity from the service and inserts the data into the SQLite DB
        /// </summary>
        /// <param name="buoy"> The Entity that is received from the service</param>
        /// <returns></returns>
        public async Task UpdateFermentabuoy(Fermentabuoy buoy)
        {
            string sql = "Update Fermentabuoy set DeviceId = @DeviceId, DeviceNumber = @DeviceNumber, MacAddress = @MacAddress where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, buoy);
            }

        }


        /// <summary>
        /// Get a summary of each buoy with the latest assignments
        /// </summary>
        /// <returns></returns>
        public async Task<List<FermentabuoySummaryDto>> GetFermentabuoySummary()
        {
            List<FermentabuoySummaryDto> summary = new List<FermentabuoySummaryDto>();
            string sql = @"select 	
                            buoy.Id as Id,
                            Batches.Id as BatchId,
                            Batches.BatchNumber as BatchNumber,
                            Beers.Name as AssignedBeerName,
                            assign.Created as AssignmentDate,
                            buoy.DeviceId as DeviceId,
                            buoy.DeviceNumber as DeviceNumber,
                            buoy.MacAddress as MacAddress
                        from Fermentabuoy buoy
                        left join (select * from FermentabuoyAssignment a
                                    left outer join FermentabuoyAssignment b
                                    on a.Fermentabuoy = b.Fermentabuoy
                                    and a.created < b.Created
                                    where b.Fermentabuoy IS NULL
                                    order by a.Created desc) 
                        assign on assign.Fermentabuoy = buoy.Id
                        left join Batches on assign.Batch = Batches.Id
                        left join Beers on Batches.Beer = Beers.Id
                        order by assign.Created desc;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                var queryResult = await db.QueryAsync<FermentabuoySummaryDto>(sql);
                summary = queryResult.ToList();
            }
            return summary;
        }


    }
}

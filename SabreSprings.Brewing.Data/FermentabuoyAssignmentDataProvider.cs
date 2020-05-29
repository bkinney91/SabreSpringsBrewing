using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class FermentabuoyAssignmentDataProvider : IFermentabuoyAssignmentDataProvider
    {


        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public FermentabuoyAssignmentDataProvider(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// This method receives a FermentationLog entity from the servcie and inserts the data into the SQLite DB
        /// </summary>
        /// <param name="log"> The Entity that is received from the service</param>
        /// <returns></returns>
        public async Task AddFermentabuoyLog(FermentabuoyAssignment assignment)
        {
            string sql = "Insert into FermentabuoyAssignment (Fermentabouy, Batch, CreatedBy) " +
                "VALUES (@Fermentabuoy, @Batch, @CreatedBy);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, assignment);
            }
        }


        /// <summary>
        /// Searches database for the the latest created assignment
        /// for this fermentabuoy
        /// </summary>
        /// <param name="fermentabuoyId"></param>
        /// <returns></returns>
        public async Task<FermentabuoyAssignment> GetLatestAssginment(int deviceId)
        {
            FermentabuoyAssignment assignment = new FermentabuoyAssignment();
            string sql = @"Select * from FermentabuoyAssignment assign join Fermentabuoy buoy on assing.Fermentabuoy = buoy.Id where buoy.DeviceId = @DeviceId order  by Created desc;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                assignment = await db.QueryFirstAsync<FermentabuoyAssignment>(sql, new { DeviceId = deviceId });
            }
            return assignment;
        }


    }
}

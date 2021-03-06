﻿using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class FermentabuoyLogDataProvider : IFermentabuoyLogDataProvider
    {
        private readonly IConfiguration _configuration;
        public FermentabuoyLogDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// This method receives a FermentationLog entity from the servcie and inserts the data into the SQLite DB
        /// </summary>
        /// <param name="log"> The Entity that is received from the service</param>
        /// <returns></returns>
        public async Task AddFermentabuoyLog(FermentabuoyLog log) 
        {            
            string sql = "Insert into FermentationLog (Name, Batch, Temperature, Gravity, Angle, DeviceId, Battery, RSSI, Created) " +
                "VALUES (@Name, @Batch, @Temperature, @Gravity, @Angle, @DeviceId, @Battery, @RSSI, @Created);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, log);
            }
            
        }

        /// <summary>
        /// Retrieves a Log entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FermentabuoyLog> GetLog(int id)
        {
            FermentabuoyLog log = new FermentabuoyLog();
            string sql = @"Select * from FermentationLog where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                log = await db.QueryFirstAsync<FermentabuoyLog>(sql, new { Id = id });
            }
            return log;
        }

        /// <summary>
        /// Retrieves all log entities from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<FermentabuoyLog>> GetAllLogs()
        {
            string sql = @"Select
                            Id,
                            Name,
                            Batch,
                            CAST(Temperature as REAL) as Temperature,
                            CAST(Gravity as REAL) as Gravity,
                            CAST(Angle as REAL) as Angle,
                            DeviceId,
                            CAST(Battery as REAL) as Battery,
                            RSSI,
                            Created
                            from FermentationLog;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                IEnumerable<FermentabuoyLog> logs = await db.QueryAsync<FermentabuoyLog>(sql);
                return logs.ToList();
            }
        }

        /// <summary>
        /// get all buoy names from db
        /// </summary>
        /// <returns></returns>
        public async Task<List<FermentabuoyLog>> GetBuoyNames()
        {
            string sql = @"Select
                            distinct name
                            from FermentationLog;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                IEnumerable<FermentabuoyLog> logs = await db.QueryAsync<FermentabuoyLog>(sql);
                return logs.ToList();
            }
        }

        /// <summary>
        /// returns all logs from db associated with given buoy.
        /// </summary>
        /// <param name="buoyName"></param>
        /// <returns></returns>
        public async Task<List<FermentabuoyLog>> GetLogsByBuoy(string buoyName)
        {
            string sql = @"Select
                            Id,
                            Name,
                            Batch,
                            CAST(Temperature as REAL) as Temperature,
                            CAST(Gravity as REAL) as Gravity,
                            CAST(Angle as REAL) as Angle,
                            DeviceId,
                            CAST(Battery as REAL) as Battery,
                            RSSI,
                            Created
                            from FermentationLog
                            where Name = @Name;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                IEnumerable<FermentabuoyLog> logs = await db.QueryAsync<FermentabuoyLog>(sql, new { Name = buoyName });
                return logs.ToList();
            }
        }


        /// <summary>
        /// returns every 8th record of logs from db associated with given batch id.
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public async Task<List<FermentabuoyLog>> GetLogsByBatchId(int batchId)
        {
            string sql = @"Select
                            Id,
                            Name,
                            Batch,
                            CAST(Temperature as REAL) as Temperature,
                            CAST(Gravity as REAL) as Gravity,
                            CAST(Angle as REAL) as Angle,
                            DeviceId,
                            CAST(Battery as REAL) as Battery,
                            RSSI,
                            Created
                            from FermentationLog
                            where Batch = @Batch";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                IEnumerable<FermentabuoyLog> logs = await db.QueryAsync<FermentabuoyLog>(sql, new { Batch = batchId });
                //if there is more than 100 hours of logs only take a log from every 4 hours
                if(logs.Count() > 100){
                    logs = logs.Where(x=> x.Id%4 ==0);
                }
                return logs.ToList();
            }
        }
    }
}

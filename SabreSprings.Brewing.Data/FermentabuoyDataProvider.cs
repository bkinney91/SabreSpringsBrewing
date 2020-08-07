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
    public class FermentabuoyDataProvider : IFermentabuoyDataProvider
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public FermentabuoyDataProvider(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
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

    }
}

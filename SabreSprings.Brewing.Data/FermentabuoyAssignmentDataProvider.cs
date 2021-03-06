﻿using Dapper;
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
using System.Linq;

namespace SabreSprings.Brewing.Data
{
    public class FermentabuoyAssignmentDataProvider : IFermentabuoyAssignmentDataProvider
    {


        private readonly IConfiguration _configuration;
        public FermentabuoyAssignmentDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

      
        public async Task AddFermentabuoyAssignment(FermentabuoyAssignment assignment)
        {
            string sql = "Insert into FermentabuoyAssignment (Fermentabuoy, Batch, CreatedBy, Created) " +
                "VALUES (@Fermentabuoy, @Batch, @CreatedBy, @Created);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, assignment);
            }
        }

        public async Task<List<FermentabuoyAssignment>> GetAllAssignments()
        {
            FermentabuoyAssignment assignment = new FermentabuoyAssignment();
            string sql = @"Select * from FermentabuoyAssignment assign join Fermentabuoy buoy on assign.Fermentabuoy = buoy.Id where buoy.DeviceId = @DeviceId order  by Created desc;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                var queryResults = await db.QueryAsync<FermentabuoyAssignment>(sql);
                return queryResults.ToList();
            }
        }


        public async Task DeleteAssignment(int id)
        {
           
            string sql = @"Delete from FermentabuoyAssignment where Id = @Id;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                await db.ExecuteAsync(sql, new {Id = id});               
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
            string sql = @"Select * from FermentabuoyAssignment assign join Fermentabuoy buoy on assign.Fermentabuoy = buoy.Id where buoy.DeviceId = @DeviceId order  by Created desc;";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                var queryResults = await db.QueryAsync<FermentabuoyAssignment>(sql, new { DeviceId = deviceId });
                if(queryResults.Any() == false)
                {
                    throw new InvalidOperationException($"Fermentabuoy {deviceId} does not have an assignment");
                }
                else
                {
                    assignment = queryResults.First();
                }
            }
            
            return assignment;
        }



    }
}

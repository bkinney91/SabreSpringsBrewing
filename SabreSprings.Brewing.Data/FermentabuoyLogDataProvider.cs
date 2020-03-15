using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.Entities;
using Serilog;
using System.Data;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data
{
    public class FermentabuoyLogDataProvider : IFermentabuoyLogDataProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public FermentabuoyLogDataProvider(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        public async Task<FermentabuoyLog> addFermentabuoyLog(FermentabuoyLog log) //take items from entity and insert them into sql statement for the db
            //-----for post man use localhost:51193/api/fermentabuoylog/post or set verb to post and leave out post.  pass json payload use json generator to get dto info and pass to function.
        {            
            string sql = "Insert into FermentationLog (Name, Temperature, Gravity, Angle, DeviceNumber, Battery, RSSI) VALUES (@Name, @Temperature, @Gravity, @Angle, @DeviceId, @Battery, @RSSI);";
            using (IDbConnection db = new SqliteConnection(_configuration.GetConnectionString("SabreSpringsBrewing")))
            {
                log = await db.QueryFirstAsync<FermentabuoyLog>(sql);
            }
            return log;
        }
    }
}

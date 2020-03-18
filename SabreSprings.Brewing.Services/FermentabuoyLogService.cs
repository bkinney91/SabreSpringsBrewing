using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using SabreSprings.Brewing.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SabreSprings.Brewing.Services
{
    public class FermentabuoyLogService : IFermentabuoyLogService
    {
        private readonly IFermentabuoyLogDataProvider FermentabuoyLogDataProvider;
        
        public FermentabuoyLogService(IFermentabuoyLogDataProvider fermentabuoyLogDataProvider)
        {
            FermentabuoyLogDataProvider = fermentabuoyLogDataProvider;      
        }

        
        /// <summary>
        /// This method takes the dto from the API controller and translates the data to a 
        /// matching entity which is then given to the data provider to be inserted into the database.
        /// </summary>
        /// <param name="fermentabuoyLogDto"> The Dto received by the controller layer</param>
        /// <returns></returns>
        public async Task<FermentabuoyLogDto> AddFermentabuoyLog(FermentabuoyLogDto fermentabuoyLogDto) 
        {            
            
            FermentabuoyLog Log = new FermentabuoyLog()            
            {
                Name = fermentabuoyLogDto.Name,
                DeviceId = fermentabuoyLogDto.DeviceId,
                Angle = fermentabuoyLogDto.Angle,
                Temperature = fermentabuoyLogDto.Temperature,
                Battery = fermentabuoyLogDto.Battery,
                Gravity = fermentabuoyLogDto.Gravity,
                RSSI = fermentabuoyLogDto.RSSI
            };
            await FermentabuoyLogDataProvider.AddFermentabuoyLog(Log);
            return Ok(Log);
        }

        private FermentabuoyLogDto Ok(FermentabuoyLog log)
        {
            throw new NotImplementedException();
        }
    }
}

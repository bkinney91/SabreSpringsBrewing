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

        

        public async Task<FermentabuoyLogDto> AddFermentabuoyLog(FermentabuoyLogDto fermentabuoyLogDto) //fix method, dont need to return dto. controller needs to give dto to this 
            //function and translate dto to entity and give entity to data provider
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

using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using SabreSprings.Brewing.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class FermentabuoyLogService : IFermentabuoyLogService
    {
        private readonly IFermentabuoyLogDataProvider FermentabuoyLogDataProvider;
        
        public FermentabuoyLogService(IFermentabuoyLogDataProvider fermentabuoyLogDataProvider)
        {
            FermentabuoyLogDataProvider = fermentabuoyLogDataProvider;      
        }

        

        public async Task<FermentabuoyLogDto> PostFermentabuoyLog() //fix method, dont need to return dto. controller needs to give dto to this 
            //function and translate dto to entity and give entity to data provider
        {
            FermentabuoyLog log = await FermentabuoyLogDataProvider.PostFermentabuoyLog();
            FermentabuoyLogDto fermentabuoyLogDto = new FermentabuoyLogDto()
            {
                Name = log.Name,
                ID = log.DeviceId,
                Angle = log.Angle,
                Temperature = log.Temperature,
                Battery = log.Battery,
                Gravity = log.Gravity,
                RSSI = log.RSSI
            };
            return fermentabuoyLogDto;
        }
    }
}

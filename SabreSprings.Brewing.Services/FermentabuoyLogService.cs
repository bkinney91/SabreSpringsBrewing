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

        

        public async Task<FermentabuoyLogDto> PostFermentabuoyLog()
        {
            FermentabuoyLog log = await FermentabuoyLogDataProvider.PostFermentabuoyLog();
            FermentabuoyLogDto fermentabuoyLogDto = new FermentabuoyLogDto()
            {
                Name = log.Name,
                ID = log.DeviceId,
                Angle = log.Angle,
                Temperature = log.Temperature,
                Batter = log.Batter,
                Gravity = log.Gravity,
                RSSI = log.RSSI
            };
            return fermentabuoyLogDto;
        }
    }
}

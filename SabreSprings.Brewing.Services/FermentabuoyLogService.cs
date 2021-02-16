using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using SabreSprings.Brewing.Data;

namespace SabreSprings.Brewing.Services
{
    public class FermentabuoyLogService : IFermentabuoyLogService
    {
        private readonly IFermentabuoyLogDataProvider FermentabuoyLogDataProvider;
        private readonly IFermentabuoyAssignmentDataProvider FermentabuoyAssignmentDataProvider;
        
        public FermentabuoyLogService(IFermentabuoyLogDataProvider fermentabuoyLogDataProvider, IFermentabuoyAssignmentDataProvider fermentabuoyAssignmentDataProvider)
        {
            this.FermentabuoyLogDataProvider = fermentabuoyLogDataProvider;
            this.FermentabuoyAssignmentDataProvider = fermentabuoyAssignmentDataProvider;
        }

        
        /// <summary>
        /// This method takes the dto from the API controller and translates the data to a 
        /// matching entity which is then given to the data provider to be inserted into the database.
        /// </summary>
        /// <param name="fermentabuoyLogDto"> The Dto received by the controller layer</param>
        /// <returns></returns>
        public async Task AddFermentabuoyLog(FermentabuoyLogDto fermentabuoyLogDto) 
        {
            FermentabuoyAssignment currentAssignment = await FermentabuoyAssignmentDataProvider.GetLatestAssginment(fermentabuoyLogDto.ID);
            FermentabuoyLog log = new FermentabuoyLog()
            {
                Name = fermentabuoyLogDto.Name,
                Batch = currentAssignment.Batch,
                DeviceId = fermentabuoyLogDto.ID,
                Angle = fermentabuoyLogDto.Angle,
                Temperature = fermentabuoyLogDto.Temperature,
                Battery = fermentabuoyLogDto.Battery,
                Gravity = fermentabuoyLogDto.Gravity,
                RSSI = fermentabuoyLogDto.RSSI,
                Created = DateTime.Now
            };
            await FermentabuoyLogDataProvider.AddFermentabuoyLog(log);   
        }

        /// <summary>
        /// Get FermentabuoyLog DTO from ID of an entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FermentabuoyLogDto> GetLog(int id)
        {
            FermentabuoyLog log = await FermentabuoyLogDataProvider.GetLog(id);
            if(log == null)
            {
                throw new ArgumentException($"Log with ID \"{id}\" was not found.");
            }
            FermentabuoyLogDto logDto = new FermentabuoyLogDto()
            {
                Name = log.Name,
                ID = log.DeviceId,
                Angle = log.Angle,
                Temperature = log.Temperature,
                Battery = log.Battery,
                Gravity = log.Gravity,
                RSSI = log.RSSI,
                Created = log.Created
            };
            return logDto;
        }

        /// <summary>
        /// Get all Logs
        /// </summary>
        /// <returns></returns>
        public async Task<List<FermentabuoyLogDto>> GetAllLogs()
        {
            List<FermentabuoyLogDto> dtos = new List<FermentabuoyLogDto>();
            List<FermentabuoyLog> entities = await FermentabuoyLogDataProvider.GetAllLogs();
            foreach (FermentabuoyLog entity in entities)
            {
                FermentabuoyLogDto fermentabuoyLogDto = new FermentabuoyLogDto()
                {
                    Name = entity.Name,
                    ID = entity.DeviceId,
                    Angle = entity.Angle,
                    Temperature = entity.Temperature,
                    Battery = entity.Battery,
                    Gravity = entity.Gravity,
                    RSSI = entity.RSSI,
                    Created = entity.Created
                };
                dtos.Add(fermentabuoyLogDto);
            }
            return dtos;
        }

        /// <summary>
        /// get all buoy names
        /// </summary>
        /// <returns></returns>
        public async Task<List<FermentabuoyLogDto>> GetBuoyNames()
        {
            List<FermentabuoyLogDto> dtos = new List<FermentabuoyLogDto>();
            List<FermentabuoyLog> entities = await FermentabuoyLogDataProvider.GetBuoyNames();
            foreach (FermentabuoyLog entity in entities)
            {
                FermentabuoyLogDto fermentabuoyLogDto = new FermentabuoyLogDto()
                {
                    Name = entity.Name                    
                };
                dtos.Add(fermentabuoyLogDto);
            }
            return dtos;
        }

        /// <summary>
        /// gets all logs for a specifc buoy name
        /// </summary>
        /// <param name="buoyName"></param>
        /// <returns></returns>
        public async Task<List<FermentabuoyLogDto>> GetLogsByBuoy(string buoyName)
        {
            List<FermentabuoyLogDto> dtos = new List<FermentabuoyLogDto>();
            List<FermentabuoyLog> entities = await FermentabuoyLogDataProvider.GetLogsByBuoy(buoyName);
            foreach (FermentabuoyLog entity in entities)
            {
                FermentabuoyLogDto fermentabuoyLogDto = new FermentabuoyLogDto()
                {
                    Name = entity.Name,
                    ID = entity.DeviceId,
                    Angle = entity.Angle,
                    Temperature = entity.Temperature,
                    Battery = entity.Battery,
                    Gravity = entity.Gravity,
                    RSSI = entity.RSSI,
                    Created = entity.Created
                };
                dtos.Add(fermentabuoyLogDto);
            }
            return dtos;
        }
    }
}


using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class FermentabuoyService
    {
        private readonly IFermentabuoyDataProvider FermentabuoyDataProvider;
        
        public FermentabuoyService(IFermentabuoyDataProvider fermentabuoyDataProvider)
        {
            FermentabuoyDataProvider = fermentabuoyDataProvider;
        }

        public async Task AddFermentabuoy(FermentabuoyDto dto)
        {
            Fermentabuoy entity = new Fermentabuoy()
            {
                DeviceId = dto.DeviceId,
                DeviceNumber = dto.DeviceNumber,
                MacAddress = dto.MacAddress,
                CreatedBy = dto.CreatedBy,
                Created = DateTime.Now
            };
            await FermentabuoyDataProvider.AddFermentabuoy(entity);
        }


        public async Task UpdateFermentabuoy(FermentabuoyDto dto)
        {
            Fermentabuoy entity = new Fermentabuoy()
            {
                Id = dto.Id,
                DeviceId = dto.DeviceId,
                DeviceNumber = dto.DeviceNumber,
                MacAddress = dto.MacAddress,
                CreatedBy = dto.CreatedBy,
                Created = DateTime.Now
            };
            await FermentabuoyDataProvider.UpdateFermentabuoy(entity);
        }

        public async Task<FermentabuoyDto> GetFermentabuoy(int id)
        {
            Fermentabuoy entity = await FermentabuoyDataProvider.GetFermentabuoy(id);
            FermentabuoyDto dto = new FermentabuoyDto()
            {
                DeviceId = entity.DeviceId,
                DeviceNumber = entity.DeviceNumber,
                MacAddress = entity.MacAddress,
                Created = entity.Created,
                CreatedBy = entity.CreatedBy
            };
            return dto;
        }

        public async Task<List<FermentabuoyDto>> GetAllFermentabuoys()
        {
            List<FermentabuoyDto> dtos = new List<FermentabuoyDto>();
            List<Fermentabuoy> entities = await FermentabuoyDataProvider.GetAllFermentabuoys();
            foreach (var entity in entities)
            {
                FermentabuoyDto dto = new FermentabuoyDto()
                {
                    DeviceId = entity.DeviceId,
                    DeviceNumber = entity.DeviceNumber,
                    MacAddress = entity.MacAddress,
                    Created = entity.Created,
                    CreatedBy = entity.CreatedBy
                };
                dtos.Add(dto);
            }
            return dtos;
        }


        

    }
}

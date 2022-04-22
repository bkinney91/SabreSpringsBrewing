using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class FermentationTankService : IFermentationTankService
    {
        private readonly IFermentationTankDataProvider FermentationTankDataProvider;
        public FermentationTankService(IFermentationTankDataProvider fermentationTankDataProvider)
        {
            this.FermentationTankDataProvider = fermentationTankDataProvider;
        }
        public async Task<FermentationTankDto> GetFermentationTank(int id)
        {
            FermentationTank tank = await FermentationTankDataProvider.GetFermentationTank(id);
            return this.MapToDto(tank);
        }

        public async Task<List<FermentationTankDto>> GetFermentationTanks()
        {
            List<FermentationTankDto> dtos = new List<FermentationTankDto>();
            List<FermentationTank> tanks = await FermentationTankDataProvider.GetFermentationTanks();
            foreach (var tank in tanks)
            {
                dtos.Add(this.MapToDto(tank));
            }
            return dtos;
        }


        private FermentationTankDto MapToDto(FermentationTank entity)
        {
            var dto = new FermentationTankDto()
            {
                Id = entity.Id,
                Type = entity.Type,
                Volume = entity.Volume,
                TankNumber = entity.TankNumber
            };
            return dto;
        }
    }
}

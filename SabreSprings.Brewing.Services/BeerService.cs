using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerDataProvider BeerDataProvider;
        public BeerService(IBeerDataProvider beerDataProvider)
        {
            BeerDataProvider = beerDataProvider;
        }


        public async Task<BeerDto> GetBeer(int id)
        {
            Beer beer = await BeerDataProvider.GetBeer(id);
            BeerDto dto = new BeerDto()
            {
                Id = beer.Id,
                Name = beer.Name,
                Style = beer.Style,
                Logo = beer.Logo,
                SuggestedGlassType = beer.SuggestedGlassType,                
                Created = beer.Created,
                CreatedBy = beer.CreatedBy
            };
            return dto;
        }

        public async Task<List<BeerDto>> GetBeers()
        {
            List<BeerDto> dtos = new List<BeerDto>();
            List<Beer> beers = await BeerDataProvider.GetBeers();
            foreach(Beer beer in beers)
            {
                BeerDto dto = new BeerDto()
                {
                    Id = beer.Id,
                    Name = beer.Name,
                    Style = beer.Style,
                    Logo = beer.Logo,
                    SuggestedGlassType = beer.SuggestedGlassType,                
                    Created = beer.Created,
                    CreatedBy = beer.CreatedBy
                };
                dtos.Add(dto);
            }
            return dtos;
        }


        

        public async Task Add(BeerDto dto)
        {           
            Beer entity = new Beer()
            {
                Name = dto.Name,
                Style = dto.Style,
                Logo = dto.Logo,
                SuggestedGlassType = dto.SuggestedGlassType,
                Created = DateTime.Now        
            };
            await BeerDataProvider.Add(entity);
        }

        public async Task Update(BeerDto dto)
        {
            Beer entity = new Beer()
            {
                Id = dto.Id,
                Name = dto.Name,
                Style = dto.Style,
                Logo = dto.Logo,
                SuggestedGlassType = dto.SuggestedGlassType      
            };
            await BeerDataProvider.Update(entity);
        }
    }
}

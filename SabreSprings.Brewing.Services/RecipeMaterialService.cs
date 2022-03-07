using SabreSprings.Brewing.Data;
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
    public class RecipeMaterialService : IRecipeMaterialService
    {
        private readonly IRecipeMaterialDataProvider RecipeMaterialDataProvider;
        public RecipeMaterialService(IRecipeMaterialDataProvider recipeMaterialDataProvider)
        {
            RecipeMaterialDataProvider = recipeMaterialDataProvider;
        }

        public async Task<RecipeMaterialDto> GetRecipeMaterial(int id)
        {
            RecipeMaterial entity = await RecipeMaterialDataProvider.GetRecipeMaterial(id);
            RecipeMaterialDto dto = new RecipeMaterialDto()
            {
                Recipe = entity.Recipe,
                Material = entity.Material,
                Created = entity.Created
            };
            return dto;
        }

        public async Task Add(RecipeMaterialDto dto)
        {
            RecipeMaterial entity = new RecipeMaterial()
            {
                Recipe = dto.Recipe,
                Material = dto.Material,
                Created = dto.Created
            };
            await RecipeMaterialDataProvider.Add(entity);
        }

        public async Task Update(RecipeMaterialDto dto)
        {
            RecipeMaterial entity = new RecipeMaterial()
            {
                Id = dto.Id,
                Material = dto.Material
            };
            await RecipeMaterialDataProvider.Update(entity);
        }

        public async Task<List<RecipeMaterialDto>> GetRecipeMaterials(int recipe)
        {
            List<RecipeMaterialDto> dtos = new List<RecipeMaterialDto>();
            List<RecipeMaterial> entities = await RecipeMaterialDataProvider.GetRecipeMaterials(recipe);
            foreach (RecipeMaterial entity in entities)
            {
                RecipeMaterialDto dto = new RecipeMaterialDto()
                {
                    Recipe = entity.Recipe,
                    Material = entity.Material,
                    Created = entity.Created
                };
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}

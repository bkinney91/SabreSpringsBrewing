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
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialDataProvider MaterialDataProvider;
        public MaterialService(IMaterialDataProvider materialDataProvider)
        {
            MaterialDataProvider = materialDataProvider;
        }

       public async Task<MaterialDto> GetMaterial(int id)
       {           
           Material entity = await MaterialDataProvider.GetMaterial(id);
           MaterialDto dto = new MaterialDto()
           {
               Description = entity.Description,
               UnitOfMeasure = entity.UnitOfMeasure,
               Type = entity.Type,
               Created = entity.Created
           };
           return dto;    
       }


       public async Task<List<MaterialDto>> GetAll()
       {           
           List<MaterialDto> dtos = new List<MaterialDto>();
           List<Material> entities = await MaterialDataProvider.GetAll();
           foreach(Material entity in entities){
            MaterialDto dto = new MaterialDto()
            {
                Description = entity.Description,
                UnitOfMeasure = entity.UnitOfMeasure,
                Type = entity.Type,
                Created = entity.Created
            };
            dtos.Add(dto);
           }
           return dtos;    
       }

       public async Task Add(MaterialDto dto)
       {
           Material entity = new Material(){
               Description = dto.Description,
               UnitOfMeasure = dto.UnitOfMeasure,
               Type = dto.Type,
               Created = dto.Created
           };
           await MaterialDataProvider.Add(entity);
       }

       public async Task Update(MaterialDto dto)
       {
           Material entity = new Material(){
               Id = dto.Id,
               Description = dto.Description,
               UnitOfMeasure = dto.UnitOfMeasure,
               Type = dto.Type
           };
           await MaterialDataProvider.Update(entity);
       }


       public async Task<List<MaterialTypeDto>> GetMaterialTypes()
       {
         List<MaterialTypeDto> dtos = new List<MaterialTypeDto>();
           List<MaterialType> entities = await MaterialDataProvider.GetMaterialTypes();
           foreach(MaterialType entity in entities){
            MaterialTypeDto dto = new MaterialTypeDto()
            {
               Id = entity.Id,
                Type = entity.Type,
                Created = entity.Created
            };
            dtos.Add(dto);
           }
           return dtos;
       }
    }
}

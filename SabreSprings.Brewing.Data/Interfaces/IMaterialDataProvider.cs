using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IMaterialDataProvider
    {
        Task<Material> GetMaterial(int id);
        Task<List<Material>> GetAll();
        Task<List<Material>> GetMaterialsByType(int type);
        Task Update(Material material);
        Task Add(Material material);
        Task<List<MaterialType>> GetMaterialTypes();
    }
}

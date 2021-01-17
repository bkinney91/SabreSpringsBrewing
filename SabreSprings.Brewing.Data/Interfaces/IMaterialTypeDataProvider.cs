using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SabreSprings.Brewing.Models.Entities;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IMaterialTypeDataProvider
    {
        Task<MaterialType> GetMaterialType(int id);
        Task<List<MaterialType>> GetMaterialTypes();
       
    }
}

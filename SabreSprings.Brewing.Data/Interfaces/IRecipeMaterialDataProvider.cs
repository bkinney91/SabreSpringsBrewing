using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SabreSprings.Brewing.Models.Entities;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IRecipeMaterialDataProvider
    {
        Task<RecipeMaterial> GetRecipeMaterial(int id);
        Task Add(RecipeMaterial step);
        Task Update(RecipeMaterial recipe);
        Task<List<RecipeMaterial>> GetRecipeMaterials(int recipe);
       
    }
}

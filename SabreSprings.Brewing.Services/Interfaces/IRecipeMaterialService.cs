using SabreSprings.Brewing.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IRecipeMaterialService
    {
        Task<RecipeMaterialDto> GetRecipeMaterial(int id);
        Task Add(RecipeMaterialDto dto);
        Task Update(RecipeMaterialDto dto);
        Task<List<RecipeMaterialDto>> GetRecipeMaterials(int recipe);
    }
}

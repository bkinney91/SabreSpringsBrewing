using SabreSprings.Brewing.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IMaterialService
    {
        Task<MaterialDto> GetMaterial(int id);
        Task Add(MaterialDto dto);
        Task Update(MaterialDto dto);
    }
}

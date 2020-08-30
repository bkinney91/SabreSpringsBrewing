using SabreSprings.Brewing.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IFermentabuoyService
    {
        Task AddFermentabuoy(FermentabuoyDto dto);
        Task UpdateFermentabuoy(FermentabuoyDto dto);
        Task<FermentabuoyDto> GetFermentabuoy(int id);
        Task<List<FermentabuoyDto>> GetAllFermentabuoys();
        Task<List<FermentabuoySummaryDto>> GetFermentabuoySummary();
    }
}

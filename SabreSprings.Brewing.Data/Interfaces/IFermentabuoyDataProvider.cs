using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IFermentabuoyDataProvider
    {
        Task AddFermentabuoy(Fermentabuoy buoy);
        Task<Fermentabuoy> GetFermentabuoy(int id);
        Task<List<Fermentabuoy>> GetAllFermentabuoys();
        Task UpdateFermentabuoy(Fermentabuoy buoy);
        Task<List<FermentabuoySummaryDto>> GetFermentabuoySummary();
    }
}

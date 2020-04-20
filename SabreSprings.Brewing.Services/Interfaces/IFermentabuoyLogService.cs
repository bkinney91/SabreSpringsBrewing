using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IFermentabuoyLogService
    {
        Task AddFermentabuoyLog(FermentabuoyLogDto fermentabuoyLogDto);
        Task<FermentabuoyLogDto> GetLog(int id);
        Task<List<FermentabuoyLogDto>> GetAllLogs();
        Task<List<FermentabuoyLogDto>> GetBuoyNames();
        Task<List<FermentabuoyLogDto>> GetLogsByBuoy(string buoyName);
    }
}

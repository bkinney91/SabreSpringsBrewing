using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IFermentabuoyLogService
    {
        Task <FermentabuoyLogDto> AddFermentabuoyLog(FermentabuoyLogDto fermentabuoyLogDto);        
    }
}

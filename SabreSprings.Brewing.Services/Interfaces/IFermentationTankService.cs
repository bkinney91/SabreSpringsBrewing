using SabreSprings.Brewing.Models.DataTransfer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IFermentationTankService
    {
        Task<FermentationTankDto> GetFermentationTank(int id);
        Task<List<FermentationTankDto>> GetFermentationTanks();
    }
}

using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface ITapService
    {
        Task<List<Tap>> GetOnTap();
        Task ProcessPour(Pour pour);
    }
}

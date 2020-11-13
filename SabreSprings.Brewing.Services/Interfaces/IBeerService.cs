using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IBeerService
    {
        Task<List<BeerDto>> GetBeers();
        Task<BeerDto> GetBeer(int id);
         Task Update(BeerDto dto);
         Task Add(BeerDto dto);        
    }
}

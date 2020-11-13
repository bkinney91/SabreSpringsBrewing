using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IBatchService
    {
        Task<List<BatchTableRow>> GetBatchTable();
        Task<BatchDetailsDto> GetBatchDetails(int id);
         Task Update(BatchDto dto);
         Task Add(BatchDto dto);
         Task<BatchDto> GetBatch(int id);
    }
}

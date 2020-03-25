using SabreSprings.Brewing.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IFermentabuoyLogDataProvider
    {
        Task AddFermentabuoyLog(FermentabuoyLog log);
        Task<FermentabuoyLog> GetLog(int id);
        Task<List<FermentabuoyLog>> GetAllLogs();

    }
}

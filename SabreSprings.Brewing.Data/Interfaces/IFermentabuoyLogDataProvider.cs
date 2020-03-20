using SabreSprings.Brewing.Models.Entities;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IFermentabuoyLogDataProvider
    {
        Task AddFermentabuoyLog(FermentabuoyLog log);

    }
}

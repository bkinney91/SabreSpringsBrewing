using SabreSprings.Brewing.Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services.Interfaces
{
    public interface IFermentabouyAssignmentService
    {
        Task AddFermentabuoyAssignment(FermentabuoyAssignmentDto dto);
    }
}

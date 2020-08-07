using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Services
{
    public class FermentabuoyAssignmentService : IFermentabouyAssignmentService
    {
        private readonly IFermentabuoyAssignmentDataProvider FermentabuoyAssigmentDataProvider;

        public FermentabuoyAssignmentService(IFermentabuoyAssignmentDataProvider fermentabuoyAssignmentDataProvider)
        {
            FermentabuoyAssigmentDataProvider = fermentabuoyAssignmentDataProvider;
        }

        public async Task AddFermentabuoyAssignment(FermentabuoyAssignmentDto dto)
        {
            FermentabuoyAssignment entity = new FermentabuoyAssignment()
            {
                Fermentabuoy = dto.Fermentabuoy,
                Batch = dto.Batch,
                CreatedBy = dto.CreatedBy,
                Created = DateTime.Now
            };
            await FermentabuoyAssigmentDataProvider.AddFermentabuoyAssignment(entity);
        }
    }
}

﻿using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IFermentabuoyAssignmentDataProvider
    {
        Task AddFermentabuoyAssignment(FermentabuoyAssignment assignment);
        Task<FermentabuoyAssignment> GetLatestAssginment(int deviceId);
    }
}

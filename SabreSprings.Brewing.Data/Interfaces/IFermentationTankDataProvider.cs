﻿using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IFermentationTankDataProvider
    {
        Task<FermentationTank> GetFermentationTank(int id);
        Task<List<FermentationTank>> GetFermentationTanks();
    }
}

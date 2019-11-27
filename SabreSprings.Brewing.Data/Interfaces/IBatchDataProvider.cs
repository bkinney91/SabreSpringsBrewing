using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IBatchDataProvider
    {
        Batch Get(int id);
        List<Batch> GetOnTap();
        List<Batch> GetAllBatches();
    }
}

using SabreSprings.Brewing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Data.Interfaces
{
    public interface IBeerDataProvider
    {
        Beer Get(int id);
        
    }
}

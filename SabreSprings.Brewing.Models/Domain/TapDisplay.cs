using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Domain
{
    public class TapDisplay
    {
        public string BeerDisplayName { get; set; }
        public int BatchNumber { get; set; }
        public string Style { get; set; }
        public string ABV { get; set; }
        public string SuggestedGlassware { get; set; }
        public string Brewers { get; set; }
        
    }
}

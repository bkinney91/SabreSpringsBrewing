using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Domain
{
    public class Tap
    {
        public string BeerDisplayName { get; set; }
        public int BatchNumber { get; set; }
        public string Style { get; set; }
        public double ABV { get; set; }
        public string SuggestedGlassType{ get; set; }
        public string Brewers { get; set; }
        public int TapNumber { get; set; }
        public decimal PintsRemaining { get; set; }
        public string TastingNotes { get; set;}
        public string Logo { get; set; }
        
    }
}

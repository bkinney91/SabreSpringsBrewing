using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Yeast { get; set; }
        public int PitchTemperature { get; set; }
        public int FermentationTemperatureLow { get; set; }
        public int FermentationTemperatureHigh { get; set; }
        public decimal StrikeWaterVolume { get; set; }
        public decimal StrikeWaterTemperature { get; set; }
        public int MashTemperature { get; set; }
        public string MashInstructions { get; set; }
        public int DaysInPrimaryFermentation { get; set; }
        public int? DaysInSecondaryFermentation { get; set; }
        public decimal PreBoilGravity { get; set; }
        public decimal OriginalGravity { get; set; }
        public decimal FinalGravity { get; set; }
        public decimal ABV { get; set; }
        public decimal? IBU { get; set; }
        public decimal? SRM { get; set; }
        public decimal? MashPh { get; set; }
        public string BrewingNotes { get; set; }
        public string FermentationNotes { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

    }
}

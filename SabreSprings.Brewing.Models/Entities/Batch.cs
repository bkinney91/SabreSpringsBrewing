﻿using System;

namespace SabreSprings.Brewing.Models.Entities
{
    public class Batch
    {
        public int Id { get; set; }
        public int Beer { get; set; }
        public int BatchNumber { get; set; }
        public string BatchName { get; set; }
        public string Status { get; set; }
        public string SubStatus { get; set; }
        public string Brewers { get; set; }
        public string Recipe { get; set; }
        public string Yeast { get; set; }
        public int FermentationTank { get; set; }
        public int TapNumber { get; set; }
        public decimal PreBoilGravity { get; set; }
        public decimal OriginalGravity { get; set; }
        public decimal FinalGravity { get; set; }
        public double ABV { get; set; }
        public decimal PintsRemaining { get; set; }
        public DateTime? DateBrewed { get; set; }
        public DateTime? DatePackaged { get; set; }
        public DateTime? DateTapped { get; set; }
        public string BrewingNotes { get; set; }
        public string TastingNotes { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

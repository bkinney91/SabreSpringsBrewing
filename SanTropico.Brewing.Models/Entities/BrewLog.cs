﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SanTropico.Brewing.Models.Entities
{
    public class BrewLog
    {
        public int Id { get; set; }
        public int Beer { get; set; }
        public int Batch { get; set; }
        public string Brewers { get; set; }
        public string Recipe { get; set; }
        public string Yeast { get; set; }
        public decimal PreBoilGravity { get; set; }
        public decimal OriginalGravity { get; set; }
        public decimal FinalGravity { get; set; }
        public decimal ABV { get; set; }
        public DateTime DateBrewed { get; set; }
        public DateTime DatePackaged { get; set; }
        public DateTime DateTapped { get; set; }
        public string BrewingNotes { get; set; }
        public string TastingNotes { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

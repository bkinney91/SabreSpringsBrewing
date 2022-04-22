using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class FermentationTank
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Volume { get; set; }
        public int TankNumber { get; set; }

        public override string ToString()
        {
            return $"{Volume.ToString("0.00")} gal. {Type} #{TankNumber}";
        }
    }
}

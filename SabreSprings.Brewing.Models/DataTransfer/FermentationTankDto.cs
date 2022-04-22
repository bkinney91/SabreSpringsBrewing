using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.DataTransfer
{
    public class FermentationTankDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Volume { get; set; }
        public int TankNumber { get; set; }
    }
}

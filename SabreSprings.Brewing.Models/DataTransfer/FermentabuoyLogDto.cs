using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.DataTransfer
{
    public class FermentabuoyLogDto
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public decimal Angle { get; set; }
        public decimal Temperature { get; set; }
        public decimal Battery { get; set; }
        public decimal Gravity { get; set; }
        public int RSSI { get; set; }
        public DateTime Created { get; set; }

    }
}

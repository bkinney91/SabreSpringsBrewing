using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class FermentabuoyLog
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int DeviceId { get; set; }
        public decimal Angle { get; set; }
        public decimal Temperature { get; set; }
        public decimal Battery { get; set; }
        public decimal Gravity { get; set; }
        public int RSSI { get; set; }
    }
}

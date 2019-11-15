using System;
using System.Collections.Generic;
using System.Text;

namespace SanTropico.Brewing.Models.Entities
{
    public class Tap
    {
        public int Id { get; set; }
        public int TapNumber { get; set; }
        public int BrewLog { get; set; }
        public decimal PintsRemaining { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

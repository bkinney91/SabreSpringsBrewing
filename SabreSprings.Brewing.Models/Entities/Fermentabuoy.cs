using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class Fermentabuoy
    {
        public int Id { get; set; }
        public int DeviceId { get; set;}
        public int DeviceNumber { get; set; }
        public string MacAddress { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }

    }
}

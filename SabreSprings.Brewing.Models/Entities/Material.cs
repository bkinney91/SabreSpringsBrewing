using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Attribute { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

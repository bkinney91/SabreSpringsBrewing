using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.DataTransfer
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public DateTime Created { get; set; }
    }
}

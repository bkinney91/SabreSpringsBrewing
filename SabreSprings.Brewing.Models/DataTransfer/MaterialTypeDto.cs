using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.DataTransfer
{
    public class MaterialTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
    }
}

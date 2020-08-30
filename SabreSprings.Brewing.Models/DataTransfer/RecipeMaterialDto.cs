using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.DataTransfer
{
    public class RecipeMaterialDto
    {
        public int Id { get; set; }
        public int Recipe { get; set; }
        public int Material { get; set; }
        public string MaterialType { get; set; }
        public string MaterialAttributes { get; set; }
        public string MaterialDescription { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

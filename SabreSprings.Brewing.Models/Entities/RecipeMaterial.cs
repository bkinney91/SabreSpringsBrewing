using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class RecipeMaterial
    {
        public int Id { get; set; }
        public int Recipe { get; set; }
        public string Material { get; set; }
        public DateTime Created { get; set; }
    }
}

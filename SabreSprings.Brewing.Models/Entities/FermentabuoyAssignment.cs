using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class FermentabuoyAssignment
    {
        public int Id { get; set; }
        public int Fermentabuoy { get; set; }
        public int Batch { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

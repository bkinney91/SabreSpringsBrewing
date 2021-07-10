using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.DataTransfer
{
    public class FermentabuoyAssignmentDto
    {
        public int Id { get; set; }
        public int Fermentabuoy { get; set; }
        public int Batch { get; set; }
        public string BeerAndBatch {get;set;}
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}

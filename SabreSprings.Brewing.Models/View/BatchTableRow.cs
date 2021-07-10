using System;

namespace SabreSprings.Brewing.Models.View
{
    public class BatchTableRow
    {
        public int BatchId { get; set; }
        public string StatusText { get; set; }    
        public int BatchNumber { get; set; }
        public string BatchName { get; set; }
        public string BeerName { get; set; }
        public string Style { get; set; }
        public string Logo{get;set;}
        public DateTime? DateBrewed { get; set; }
        public DateTime? DatePackaged { get; set; }
        
    }
}

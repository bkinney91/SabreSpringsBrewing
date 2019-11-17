using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string UnitOfMeasure { get; set; }
        public string PricePerUnitOfMeasure { get; set; }
        public decimal Quantity { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class BillOfMaterial
    {
        public int Id { get; set; }
        public int Batch { get; set; }
        public int Inventory { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

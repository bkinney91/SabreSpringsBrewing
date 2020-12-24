using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.DataTransfer
{
    public class FermentabuoySummaryDto
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int BatchNumber { get; set; }
        public string AssignedBeerName { get; set; }
        public DateTime AssignmentDate { get; set; }
        public int DeviceId { get; set; }
        public int DeviceNumber { get; set; }
        public string MacAddress { get; set; }
        
    }
}

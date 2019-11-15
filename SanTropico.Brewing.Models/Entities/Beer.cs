using System;
using System.Collections.Generic;
using System.Text;

namespace SanTropico.Brewing.Models.Entities
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

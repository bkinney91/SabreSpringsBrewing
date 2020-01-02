using System;

namespace SabreSprings.Brewing.Models.Entities
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public string Logo { get; set; }
        public string SuggestedGlassType { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}

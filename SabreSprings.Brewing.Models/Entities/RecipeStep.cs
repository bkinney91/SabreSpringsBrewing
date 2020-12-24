using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.Entities
{
    public class RecipeStep
    {
        public int Id { get; set; }
        public int Recipe { get; set; }
        public string Stage { get; set; }
        public int StepNumber { get; set; }
        public string DisplayText { get; set; }
        public int? TimerMinutes { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SabreSprings.Brewing.Models.DataTransfer
{
    public class RecipeStepDto
    {
        public int Id { get; set; }
        public int Recipe { get; set; }
        public int Stage { get; set; }
        public int StepNumber { get; set; }
        public string DisplayText { get; set; }
        public int? TimerMinutes { get; set; }     
        public DateTime Created {get;set;}   
    }
}
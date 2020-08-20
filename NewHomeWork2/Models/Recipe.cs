using System;
using System.Collections.Generic;
using System.Text;

namespace NewHomeWork2.Models
{
    class Recipe:BaseModel
    {

        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> StepList { get; set; } = new List<string>();
    }
}

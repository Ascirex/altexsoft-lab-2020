using System.Collections.Generic;

namespace NewHomeWork2.Models
{
	internal class Recipe : BaseModel
	{
		public string Description { get; set; }
		public List<string> Steps { get; set; } = new List<string>();
		public List<int> IngredientsIds { get; set; } = new List<int>();
	}
}

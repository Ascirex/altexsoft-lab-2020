using System;
using System.Collections.Generic;

namespace NewHomeWork2.Models
{
	internal class SubCatalog : BaseModel
	{
		public List<int> RecipesIds { get; set; } = new List<int>();
	}
}

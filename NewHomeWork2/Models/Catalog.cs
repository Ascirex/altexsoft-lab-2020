using System;
using System.Collections.Generic;
using System.Linq;

namespace NewHomeWork2.Models
{
	internal class Catalog : BaseModel
	{
		public List<int> SubCatalogsIds { get; set; } = new List<int>();
	}

}

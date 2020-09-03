using System;

namespace NewHomeWork2.Models
{
	internal abstract class BaseModel 
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public override string ToString()
        {
            return $"  Название: {Name}\n\t №:[{Id}]\n"; 
        }
	}
}
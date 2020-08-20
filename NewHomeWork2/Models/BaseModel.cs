using System;
using System.Collections.Generic;
using System.Text;

namespace NewHomeWork2.Models
{
    abstract class BaseModel
    {
        protected BaseModel()
        {
            Random random = new Random(4);
            int i = random.Next();
             
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Label: {Name}, type:   {this.GetType().Name}, ID{Id}"
        }

    }
}

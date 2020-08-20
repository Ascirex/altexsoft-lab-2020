using System;
using System.Collections.Generic;
using System.Text;

namespace NewHomeWork2.Models
{
    class Catalog:BaseModel
    {
        public List<SubCatalog> SubCatalogs { get; set; } = new List<SubCatalog>();

    }

}

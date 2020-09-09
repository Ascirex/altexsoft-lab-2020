using System;
using System.Collections.Generic;
using System.Text;
using NewHomeWork2.Models;

namespace NewHomeWork2.Repositories
{
    internal class SubCatalogRepository : Repository<SubCatalog>
    {
        public SubCatalogRepository() : base(Constants.SubCatalogsFileName)
        {
            
        }
    }
}

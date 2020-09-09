using NewHomeWork2.Models;

namespace NewHomeWork2.Repositories
{
	internal class CatalogsRepository: Repository<Catalog>
	{
		public CatalogsRepository() : base(Constants.CatalogsFileName)
		{
		}
	}
}
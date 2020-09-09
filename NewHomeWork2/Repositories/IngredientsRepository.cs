using NewHomeWork2.Models;

namespace NewHomeWork2.Repositories
{
	internal class IngredientsRepository : Repository<Ingredient>
	{
		public IngredientsRepository() : base(Constants.IngredientsFileName)
		{
		}
	}
}
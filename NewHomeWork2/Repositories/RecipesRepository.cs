using NewHomeWork2.Models;

namespace NewHomeWork2.Repositories
{
	internal class RecipesRepository : Repository<Recipe>
	{
		public RecipesRepository() : base(Constants.RecipesFileName)
		{
		}
	}
}
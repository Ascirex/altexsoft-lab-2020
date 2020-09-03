using System;
using System.Collections.Generic;
using NewHomeWork2.Models;
using NewHomeWork2.Repositories;

namespace NewHomeWork2.UserInteractions
{
	internal class CatalogsInteraction : BaseInteraction
	{
		private readonly CatalogsRepository _catalogsRepository = new CatalogsRepository();
		public CatalogsInteraction(BaseInteraction previousInteraction) : base(previousInteraction)
		{
		}

		public override string GetHistory()
		{
			return "> Каталог";
		}

		protected override void StartInteraction()
		{
			var choice = ConExt.ReadChoice();
			switch (choice)
			{
				case 1:
					ChooseCatalogs();
					break;
				case 2:
					CreateCatalog();
					break;
				default:
					ConExt.WriteLine("Пока еще нет такой функции");
					StartInteraction();
					break;
			}
		}

		protected override void ShowOptions()
		{
			ConExt.WriteLine(" ");

			ConExt.WriteSelect(1);
			ConExt.WriteLine("Открыть каталог");
			ConExt.WriteSelect(2);
			ConExt.WriteLine("Создать каталог");
			ConExt.WriteSelect(3);
			ConExt.WriteLine("Удалить подкаталог");
		}

		protected override void ShowMainInfo()
		{
			ConExt.WriteLine("Список каталогов:");
            var i = 1;
			foreach (Catalog catalog in _catalogsRepository.GetAll())
			{
				ConExt.WriteLine($" {i++} " + catalog.Name);
			}
		}

	
		private void ChooseCatalogs()
		{
			ConExt.WriteLine("Список каталогов:");
			Dictionary<int, Catalog> catalogsDict = new Dictionary<int, Catalog>();
			var key = 0;

			foreach (Catalog catalog in _catalogsRepository.GetAll())
			{
				key++;
				ConExt.WriteSelect(key);
				ConExt.WriteLine(catalog.Name);

				catalogsDict[key] = catalog;
			}

			ConExt.WriteLine("\n");
			ConExt.WriteLine("Выберите каталог: ");
			
			var choice = ConExt.ReadChoice();
			if (catalogsDict.TryGetValue(choice, out var selectedCatalog))
			{
				new SelectedCatalogInteraction(this, selectedCatalog)
					.Start();
			}
			else
			{
				this.Start();
			}
		}

		private void CreateCatalog()
		{
			ConExt.WriteLine("Введите имя каталога");
			var catalogName = Console.ReadLine();
			var catalog = new Catalog
			{
				Name = catalogName
			};

			_catalogsRepository.Add(catalog);

			Start();
		}
	}
}
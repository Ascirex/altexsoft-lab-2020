using System;
using System.Collections.Generic;
using NewHomeWork2.Models;
using NewHomeWork2.Repositories;

namespace NewHomeWork2.UserInteractions
{
	internal class SelectedCatalogInteraction:BaseInteraction
	{
		private readonly SubCatalogRepository _subCatalogsRepository = new SubCatalogRepository();
		private readonly CatalogsRepository _catalogsRepository = new CatalogsRepository();
		private readonly Catalog _selectedCatalog;

		public SelectedCatalogInteraction(CatalogsInteraction catalogsInteraction, Catalog selectedCatalog) 
			: base(catalogsInteraction)
		{
			_selectedCatalog = selectedCatalog;
		}

		public override string GetHistory()
		{
			return _previousInteraction.GetHistory() + $" > {_selectedCatalog.Name}";
		}

		protected override void StartInteraction()
		{
			var choice = ConExt.ReadChoice();
			switch (choice)
			{
				case 0:
					_previousInteraction.Start();
					return;
				case 1:
					RenameCatalog();
					break;
				case 2:
					ChooseSubCatalogs(); 
					return;
				default:
					ConExt.WriteLine("Пока еще нет такой функции");
					StartInteraction();
					break;
			}
		}
		protected override void ShowOptions()
		{
			ConExt.WriteLine("Выберите следующее действие: ");

			ConExt.WriteSelect(0);
			ConExt.WriteLine("< Назад");
			ConExt.WriteSelect(1);
			ConExt.WriteLine("Переименовать каталог");
			ConExt.WriteSelect(2);
			ConExt.WriteLine("Открыть подкаталог");
			ConExt.WriteSelect(3);
			ConExt.WriteLine("Создать подкаталог");
			ConExt.WriteSelect(4);
			ConExt.WriteLine("Удалить подкаталог");
		}

		protected override void ShowMainInfo()
		{

            ConExt.WriteLine($"Название: {_selectedCatalog.Name}");
			ConExt.WriteLine($"Номер ID: {_selectedCatalog.Id}");
			ConExt.WriteLine("Список подкаталогов:");
			foreach (var subCatalog in _subCatalogsRepository.GetAll())
			{
				if (_selectedCatalog.SubCatalogsIds.Contains(subCatalog.Id))
				{
					ConExt.WriteLine(" - " + subCatalog.Name);
				}
			}
		}

		private void ChooseSubCatalogs()
		{
			ConExt.WriteLine("Выберите подкаталог: ");
			Dictionary<int, SubCatalog> subCatalogsDict = new Dictionary<int, SubCatalog>();
			
			var key = 0;

			foreach (var subCatalog in _subCatalogsRepository.GetAll())
			{
				if (_selectedCatalog.SubCatalogsIds.Contains(subCatalog.Id))
				{
					key++;
					ConExt.WriteSelect(key);
					ConExt.WriteLine(subCatalog.Name);
					subCatalogsDict[key] = subCatalog;
				}
			}

			// надо дописать
		}

		private void RenameCatalog()
		{
			Console.WriteLine("Введите новое название: ");
			var catalogName = Console.ReadLine();

			_selectedCatalog.Name = catalogName;

			_catalogsRepository.Update(_selectedCatalog);

			Start();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NewHomeWork2.Models;
using NewHomeWork2.Repositories;

namespace NewHomeWork2
{
    internal class ShowLists
    {
        RecipesRepository recipe = new RecipesRepository();
        IngredientsRepository ingredient = new IngredientsRepository();
        CatalogsRepository catalog = new CatalogsRepository();
        SubCatalogRepository subCatalog = new SubCatalogRepository();
        List<string> resultList = new List<string>();

        public void Show()
        {
            ShowCatalog(); 
            ShowSubCatalogs();

        }
        private void ShowCatalog()
        { 
            conExt.Clear(); 
            conExt.WriteLine("\n Добро пожаловать в кулинарную книгу!",ConsoleColor.Cyan);
            conExt.WriteLine(" Пожалуйста, выберите этап из списка:\n");

            var select1 = 1;

            foreach (var res in catalog.GetAll())
            {
                conExt.Select(select1++); 
                conExt.Write($" {res.Name}",ConsoleColor.Yellow);
                conExt.Write($"     [{res.Id}]\n",ConsoleColor.DarkGray);
            }

            var x = int.Parse(Console.ReadLine().ToString());
             

        }

        private void ShowSubCatalogs()
        {
           
        }
    }

}

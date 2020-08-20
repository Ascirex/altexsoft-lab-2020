using NewHomeWork2.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Cache;
using System.Text;
using System.Collections.Generic;

namespace NewHomeWork2
{
    

    class Program
    {
        static void Main(string[] args)
        {
            SetSettings();
            var ingredient = new Ingredient();

            var recipe = new Recipe();
            recipe.Ingredients = new List<Ingredient>();
            recipe.Ingredients.Add(ingredient);

            var subCatalog = new SubCatalog();
            subCatalog.Recipe.Add(recipe);

            var catalog = new Catalog();
            catalog.SubCatalogs.Add(subCatalog);





            Console.WriteLine("End Programm");
            Console.ReadKey();
        }

        static void SetSettings()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "New homework №1 v0.3";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}

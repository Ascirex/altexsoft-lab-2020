using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using NewHomeWork2.Models;
using NewHomeWork2.Repositories;
using NewHomeWork2.UserInteractions;

namespace NewHomeWork2 
{
	  internal class Program 
    {

        private static void Main(string[] args)
	    {
		    SetSettings();

		    CatalogsInteraction catalogsUserInteraction = new CatalogsInteraction(null);
		    catalogsUserInteraction.Start();

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

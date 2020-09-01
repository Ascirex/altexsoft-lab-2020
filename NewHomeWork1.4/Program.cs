using System;
using System.Globalization;
using System.Text;

namespace NewHomeWork1._4
{
    internal class Program
    {

        static void Main(string[] args)
         {
            SetSettings();
            

            var selector = new Selector();
                selector.Begin();

                #region END PROGRAM 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n The end.\n  До скорого :)\n");
            Console.ReadKey();
            #endregion
        }

        private static void SetSettings()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "New homework №1 v0.3";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
}

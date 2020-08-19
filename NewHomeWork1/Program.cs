using System;
using System.Text;

namespace NewHomeWork1
{
    class Program
    {

        static void Main(string[] args)
        {
            SetSetings(); //установка параметров для консоли

            Selector StartProgram = new Selector();   
            StartProgram.Begin(); //Начало 


            #region THE END
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n   End Program");
            Console.ReadKey();
            #endregion
        }
        static void SetSetings()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "New homework №1 v0.3";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

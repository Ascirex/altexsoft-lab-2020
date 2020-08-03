using System;
using System.Collections.Generic;


namespace qwe
{
    class Program
    {
        static int    sel = 0;
        static string filePathText = @"./WorkText.txt"; //default path
    
        
         static void Main(string[] args)  //static async Task Main(string[] args) 
        {
            string _sel = "";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "AscHomeWork v0.01a :3" ;
            SelectorX  selec = new SelectorX(filePathText,ref sel); //передаются параметры ссылки и "нажатие" кнопки
            selec.Language();

            do
            {
                selec.Select();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n {Text.TextTransfer} ({selec.filePathText})");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n [Y]");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" YES\t|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\t[N]"); 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" NO\n ");
                Console.ForegroundColor = ConsoleColor.White;

                _sel = Console.ReadKey().Key.ToString();
                Console.Clear();
                Console.WriteLine(_sel);
            }
            while (_sel!="Y" );

            filePathText = selec.filePathText;
            TextModif modifyText = new TextModif(selec.textForChanges, filePathText);
            modifyText.BeginChanges();




            #region TheEnd
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n EXIT :3 Goodluck :)");
            Console.ReadKey();
            #endregion
        }

          
    }
}

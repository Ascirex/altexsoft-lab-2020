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
            Console.Title = "AscHomeWork v0.01a :3" ;
            SelectorX  selec = new SelectorX(filePathText,ref  sel); //передаются параметры ссылки и "нажатие" кнопки
            selec.Language();
            selec.Select();

             filePathText = selec.filePathText;

            //Console.WriteLine("Сделаем вид что все ок)");
             Console.WriteLine(selec.textForChanges);

            TextModif modifyText = new TextModif();




            #region TheEnd
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n Конец проги");
            Console.ReadKey();
            #endregion
        }

      
    }
}

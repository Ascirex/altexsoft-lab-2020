using System;
using System.Collections.Generic;


namespace qwe
{
    class Program
    {
        static int _sel = 0;
        static string _filePathText = @"./WorkText.txt"; //default path
        
         static void Main(string[] args)  //static async Task Main(string[] args) 
        {
            SelectorX _select = new SelectorX(_filePathText,ref _sel); //передаются параметры ссылки и "нажатие" кнопки
            _select.Language();
            _select.Select();

            _filePathText = _select.filePathText;

            Console.WriteLine(_select.textForChanges);

            TextModif _modifyText = new TextModif();




            #region TheEnd
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n Конец проги");
            Console.ReadKey();
            #endregion
        }

      
    }
}

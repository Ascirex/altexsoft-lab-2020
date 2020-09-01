using System;
using NewHomeWork1._4.FileBuilder;
using NewHomeWork1._4.Methods;

namespace NewHomeWork1._4
{
    internal class Selector
    {
        public string DefaultFilePath { get; set; }
         
        public void Begin()
        {
            ConsoleExt.Write("\n\tДобро пожаловать в редакторный информатор v0.99\n " +
                             "Нажмите, пожалуйста, соответствующую кнопку для выбора действия: \n\n\n", ConsoleColor.Yellow);
            ConsoleExt.WriteSelect(1,3);
            ConsoleExt.Write("Ввести путь к файлу вручную\n");
            ConsoleExt.WriteSelect(2,3);
            ConsoleExt.WriteLine("Выбрать стандартный файл (WorkText.txt)\n\n    ");

            GetChoice(); 
        }

        private void GetChoice()
        {
            var pathCreator = new FileListGen();
            try
            {
                switch (int.Parse(Console.ReadKey().KeyChar.ToString()))
                {
                    case 1:
                       
                        pathCreator.GetStart();
                        break;
                    case 2:
                        var textWorker = new SelectTextWork(Constants.DefaultPath);
                        textWorker.SelectWork();
                        break;
                    default:
                        ConsoleExt.WriteLine("\n\n Пожалуйста, используйте цифры для ввода.\n ");  
                        Console.ReadKey();
                        ConsoleExt.Clear();
                        Begin();
                        break;
                }
            }
            catch
            {
                ConsoleExt.WriteLine("\n\n Пожалуйста, используйте цифры для ввода.\n ");
                Console.ReadKey();
                ConsoleExt.Clear();
                Begin();
            }

            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace NewHomeWork1
{
    class Selector  
    {   
        int _sel;
        public void Begin()
        { 
            ConsoleExt.Write(" Ну что, приступим к работе? Выберите один из пунктов: \n\n",ConsoleColor.Yellow);
            ConsoleExt.WriteSelect(1);
            ConsoleExt.Write("Ввести путь к папке вручную\n");
            ConsoleExt.WriteSelect(2);
            ConsoleExt.Write("Ввести путь к файлу автоматически (в папке)\n ");
            ReadChoice(1); 
            
        }
        void ReadChoice(int id)
        {
            
            try { 
            _sel = Console.ReadKey().KeyChar;
            FilePathBuilder filePathBuilder = new FilePathBuilder();

            switch (_sel)
            {
                case 49:
                        ConsoleExt.Clear();
                        Console.Write ($"\n Введите путь к файлу, (к примеру ");
                        ConsoleExt.Write("D:/", ConsoleColor.Cyan);
                        ConsoleExt.Write(" или ");
                        ConsoleExt.Write("D:/Новый папк1/", ConsoleColor.Cyan);
                        ConsoleExt.Write("):\n");
                        
                        string x = Console.ReadLine();
                        filePathBuilder.CreatePath(x); 
                        break;

                case 50: 
                        filePathBuilder.ReadyPath();
                        break;

                default:
                    ConsoleExt.WriteLine("\n Сорямба, но ввести нужно цифру 1, 2, или то что там доступно.\n Введи теперь нормально :)\n ", ConsoleColor.Gray);
                    ReadChoice(id);
                    break;
            }
            }
            catch  
            {
                ConsoleExt.WriteLine($"\n Сорямба, но ты умудрился довести програмку до инфаркта, радуйся :) \n В общем введи путь по человечески, и все будет ок. \n",ConsoleColor.Green);
                Console.ReadKey();
                ConsoleExt.Clear();
                Begin();
            } 
        }


    }
}

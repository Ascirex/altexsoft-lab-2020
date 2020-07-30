using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace qwe
{
    class Program
    {
        static int _sel;
        static string _filePathText = @"./WorkText.txt"; //default path
        
        static async Task Main(string[] args) //static void Main(string[] args)
        {
            Language(); //Выбор языка для удобства 
            Select(); //Выбор первого варианта
            

            #region TheEnd
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n Конец проги");
            Console.ReadKey();
            #endregion
        }

       static void ReadFilePath()
        {
            DirectoryInfo dirinfo = new DirectoryInfo(_filePathText);

            try
            {
                using (StreamReader sr = new StreamReader(_filePathText))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }catch 
            {
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Text.errOpened);
                Console.ForegroundColor = ConsoleColor.White;
            }


        }
        static void Select()
        {
            Console.Clear();
            Console.WriteLine("\n " + Text.Test);//Выбранный язык - русский
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n {Text.Select}"); //Пж, выберите что дальше:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n {Text.Select1}");//предложенные варианты
            Console.WriteLine($"\n {Text.Select1_1}\n {Text.Select1_2}\n {Text.Select1_3}\n");//варианты
            
            // === SELECTOR ===
            try 
            {
                _sel = Console.ReadKey().KeyChar;
                switch(_sel)
                {
                    case 49: // 1
                        Console.WriteLine("\n 1");
                        break;

                    case 50: // 2
                        Console.WriteLine("\n 2");
                        break;

                    case 51: // 3 read WorkText.txt
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" \n {Text.isOpened} \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        ReadFilePath();
                        break;

                    default: //if error
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Text.Select1Err);
                        Console.ForegroundColor = ConsoleColor.White;
                        Select();
                        break;
                }

            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Text.Select1Err);
                Console.ForegroundColor = ConsoleColor.White;
                Select();
            }
        }

        static void Language()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Please, select language: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n [1] English;\n [2] Русский;\n");
            Console.ForegroundColor = ConsoleColor.White;
            //проверка на адекватность :D
            try
            {
                _sel = Console.ReadKey().KeyChar;
                switch (_sel)
                {
                    case 49: //1 = 49
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-EN");
                        break;
                    case 50:
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(" - Plz, use 1 or 2 button");
                        Language();
                        break;
                }
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  Sorry, but your number is not aviable, plz select 1 or 2. \n");
                Console.ForegroundColor = ConsoleColor.White;
                Language();
            }
        }
    }
}

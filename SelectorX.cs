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
   
    class SelectorX
    {
        int selID { get; set; }
        public string filePathText { get; set; }
        public string textForChanges { get; set; } = "File not found";
        public SelectorX(string filePath, ref int _selectID)
        {
            this.selID = _selectID;
            this.filePathText = filePath;
        }
       
        public void Select()   // выборка
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
                    selID = Console.ReadKey().KeyChar;
                    switch (selID)
                    {
                        case 49: // 1
                            Console.WriteLine("\n 1");
                            break;

                        case 50: // 2
                            Console.Clear();
                            Console.WriteLine($"\n\n {Text.Select2}");
                            filePathText = Console.ReadLine();
                            ReadFile();
                            
                        break;

                        case 51: // 3 read WorkText.txt
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" \n {Text.isOpened} \n");
                            Console.ForegroundColor = ConsoleColor.White;
                            ReadFile();
                    
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
        public void Language()  // язык
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
                selID = Console.ReadKey().KeyChar;
                switch (selID)
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
        public void ReadFile() //открытие файла, передать сюда filePathText
        {
            DirectoryInfo dirinfo = new DirectoryInfo(filePathText);

            try
            {
                using (StreamReader sr = new StreamReader(filePathText))
                {
                    textForChanges = sr.ReadToEnd();
                }
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n "+Text.errOpened+" " + textForChanges);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }


    }
    }


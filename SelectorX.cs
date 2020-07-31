﻿using System;
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
        int _enterID=1;
        string _createPath = "";
        public SelectorX(string filePath, ref int  selectID)
        {
            this.selID =  selectID;
            this.filePathText = filePath;
        }
       
        public void FinderPath()
        {
            Console.Clear();
            Console.WriteLine($"\n {Text.Finder1}\n\n{Text.Finder1_1} ");

            DriveInfo[] driveINF = DriveInfo.GetDrives();
            foreach (DriveInfo drive in driveINF) //Показывает доступные диски
            {
                if (drive.DriveType != DriveType.Fixed)
                    continue;
                string fullpath = drive.RootDirectory.FullName;
                Console.WriteLine(" >> "+ fullpath);
            }

            _createPath = Console.ReadKey().Key.ToString()+":/";
            Console.WriteLine("\n Путь сейчас: "+_createPath+"\n");
            _enterID = 0;

            DirectoryInfo dir = new DirectoryInfo(_createPath);
            List<string> listfiles = new List<string>();

            foreach (DirectoryInfo papkes in dir.GetDirectories())   //Вывод папок
            {
                listfiles.Add("Dir: "+papkes.Name);     
            }
            foreach (FileInfo files in dir.GetFiles())     //Вывод файлов
            {
                listfiles.Add("File: -"+files.Name);
            }
            
            foreach (var str in listfiles)    // Вывод на экран
            {
                _enterID++;
                Console.WriteLine(_enterID +". "+ str );
            }
            Console.WriteLine($"\n {Text.Finder1_2}");
            string ss= Console.ReadLine();

            FinderPath();


            Console.WriteLine("\n конец пасфайндера");
            Console.ReadLine();
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
                    
                            FinderPath();
                            break;

                        case 50: // 2
                            Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\n {Text.Select2}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        filePathText = Console.ReadLine();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($" \n {Text.isOpened} \n");
                        Console.ForegroundColor = ConsoleColor.White;
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
                Console.ReadKey();
                filePathText = @"./WorkText.txt";
                Select();
            }

        }


    }
    }


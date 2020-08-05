using System;
using System.Collections;
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
    class FinderPathDirs
    {
        private int _dirID=1;
        public int dirID { get { return _dirID; } set { _dirID = value; } }
        public string Name { get; set; }
        public string Type { get; set; }

        public String getName()
        {
            return Name;
        }
        public String getType()
        {
            return Type;
        }

        public int getID()
        {
            return dirID;
        }

    }

    class SelectorX
    {
        int selID { get; set; }
        public string filePathText { get; set; }
        public  string textForChanges { get; set; } = "File not found";
        int _enterID=1;
        string _createPath = "";

        public SelectorX(string filePath, int  selectID)
        {
            this.selID =  selectID;
            this.filePathText = filePath;
        }

        public void FinderPath()
        {
            Console.Clear();
            if (_createPath == "")
            {
                Console.WriteLine($"{Text.Select2}");
                _createPath = Console.ReadLine();
            }
            else { 

            Console.WriteLine($" \n{Text.Finder1_3} \n");
            }
            _enterID = 0;
          
            DirectoryInfo dir = new DirectoryInfo(_createPath);
            List<FinderPathDirs> arrlist = new List<FinderPathDirs>();
            List<FinderPathDirs> dirsList = new List<FinderPathDirs>();
            List<FinderPathDirs> fileList = new List<FinderPathDirs>();

            foreach (DirectoryInfo papkes in dir.GetDirectories())   //Вывод папок
            {
                _enterID++;
               dirsList.Add(new FinderPathDirs() { Name = papkes.Name, Type = "Dir", dirID = _enterID });
         
            }

            foreach (FileInfo files in dir.GetFiles())     //Вывод файлов
            {
                _enterID++;
                fileList.Add(new FinderPathDirs() { Name = files.Name, Type = "File", dirID = _enterID });
            }
            
            dirsList = dirsList.OrderBy(ob => ob.Name).ToList();
            fileList = fileList.OrderBy(ob => ob.Name).ToList();

            foreach (var XX in dirsList)
            {
                arrlist.Add(XX);
            }
            foreach (var XX in fileList)
            {
                arrlist.Add(XX);
            }

            foreach (FinderPathDirs finder in arrlist)    // Вывод на экран
            {
                Console.WriteLine( $"{finder.dirID}. {finder.Type}| {finder.Name}") ;
            }
            Console.WriteLine($">> {Text.FinderBack}");
            Console.WriteLine($"\n Path: {_createPath}\n {Text.Finder1_2}");
            FinderPathDirs arrls = new FinderPathDirs();

          
            //Попытка стянуть данные

            try
            { 
             int ss = Convert.ToInt32( Console.ReadLine());
                arrls = (FinderPathDirs)arrlist[ss - 1];
                if (arrls.getType() == "Dir") {
                _createPath += arrls.getName() + "/";
                    FinderPath();
                }
                else if (arrls.getType() == "File")
                {
                    _createPath += arrls.getName();
                    filePathText = _createPath;
                    Console.Clear();
                    ReadFile();
                }

            }
            catch
            {
                Console.WriteLine($"\n {Text.errFinder1}");
                Console.ReadKey();
                _createPath = "";
                FinderPath();
            }

        }
        

        public void Select()   // выборка
            {
                _createPath = "";
                Console.Clear();
                Console.WriteLine("\n " + Text.Test);//Выбранный язык - русский
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n {Text.Select}"); //Пж, выберите что дальше:
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n {Text.Select1}");//предложенные варианты
                Console.WriteLine($"\n {Text.Select1_1}\n {Text.Select1_3}\n");//варианты

                // === SELECTOR ===
                try
                {
                    selID = Console.ReadKey().KeyChar;
                    switch (selID)
                    {
                        case 49: // 1
                    
                            FinderPath();
                            break;

                        case 50: // 3 read WorkText.txt
                            Console.Clear();
                            filePathText = @"./WorkText.txt";
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
                    _createPath = "";
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


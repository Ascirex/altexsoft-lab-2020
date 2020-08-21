using System;
using System.Collections.Generic; 
using System.IO;
using System.Linq;

namespace NewHomeWork1
{
    // Тут все что касается считывания пути к файлу и его построения. (все почти в одном классе)
    class FilePath
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } 
    }

    class FilePathBuilder //Начало. Место где вводится путь к файлу + "создание пути" по ходу программы. 
    {
        FileTextReader reader = new FileTextReader();
        public string DefaultPath { get { return "./WorkText.txt"; } }
         public string CreatedPath { get; set; } = "";
         public int dirsID = 0;
         
        public void CreatePath(string enteredPath)
        {
            ConsoleExt.Clear();
            Console.WriteLine("\n  --[PathBuilder v0.2]--"); // тестовое сообщение

            CreatedPath = enteredPath;

            if (CreatedPath == "")
            {
                ConsoleExt.Clear();
                Console.WriteLine("\n Введите путь к папке");
                ConsoleExt.WriteLine(" (к примеру D:/Новая папка1/ )", ConsoleColor.Yellow);
                CreatedPath = Console.ReadLine();
            }
            else
            {
                ConsoleExt.WriteLine("\n  Куда перейти дальше?\n", ConsoleColor.Red);
            }
         
            dirsID = 0;
            DirectoryInfo dirinfo = new DirectoryInfo(CreatedPath); 
            List<FilePath> dirslist = new List<FilePath>();
            List<FilePath> fileList = new List<FilePath>();
             
            //добавление списка файлов к листам
            foreach (DirectoryInfo dirs in dirinfo.GetDirectories())
            {
                dirsID++;
                dirslist.Add(new FilePath() { ID = dirsID, Name = dirs.Name, Type = "Dir " });
            }
            foreach (FileInfo files in dirinfo.GetFiles())
            {
                dirsID++;
                fileList.Add(new FilePath() { ID = dirsID, Name = files.Name, Type = "File" });
            }
            dirslist = dirslist.OrderBy(ob => ob.Name).ToList(); //сортировка
            fileList = fileList.OrderBy(ob => ob.Name).ToList();
            
            List<FilePath> resultList = new List<FilePath>();
            foreach (var names in dirslist)
            {
                resultList.Add(names);
            }
            foreach(var names in fileList)
            {
                resultList.Add(names);
            }
            //Вывод на экран списка файлов
            foreach (FilePath  finder in resultList)
            { 
                ConsoleExt.WriteSelect(finder.ID);
                if (finder.Type =="Dir ")
                ConsoleExt.Write($"|{ finder.Type}", ConsoleColor.DarkGray);
                if (finder.Type == "File")
                ConsoleExt.Write($"|{ finder.Type}", ConsoleColor.DarkCyan);
                Console.Write($"| {finder.Name}\n");
            } 

            FilePath result = new FilePath();
            try
            {
                int ss = Convert.ToInt32(Console.ReadLine());
                result = (FilePath)resultList[ss - 1];
                //Конструктор пути к файлу
                if (result.Type == "Dir ")
                {
                    CreatedPath += result.Name+ "/";
                    CreatePath(CreatedPath);
                }
                else if (result.Type == "File")
                {
                    CreatedPath += result.Name;

                    Console.Clear();
                    reader.TextReader(CreatedPath); 
                } 
            }
            catch
            {
                //сброс
                Console.WriteLine($"\n Не правильный путь, давай по новой :)");
                Console.ReadKey(); 
                CreatedPath = "";
                CreatePath(CreatedPath);
            } 
        }
        //если выбран готвоый вариант, то возвращается стандартный путь
        public void ReadyPath()
        {
            ConsoleExt.Clear(); 
            reader.TextReader(DefaultPath);
        }

    }
    
}

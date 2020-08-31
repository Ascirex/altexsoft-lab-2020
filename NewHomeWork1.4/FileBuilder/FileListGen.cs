using NewHomeWork1._4.Methods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NewHomeWork1._4.FileBuilder
{
    internal class FileListGen
    {
        private static string _fileCreatePath="";
        private int _folderIndex; //если что - он используется 
        private List<FilePathListConstructor> dirList = new List<FilePathListConstructor>();
        private List<FilePathListConstructor> fileList = new List<FilePathListConstructor>();
        private List<FilePathListConstructor> resultList = new List<FilePathListConstructor>();


        public void GetStart()
        {
            Console.Clear();
            ConsoleExt.WriteLine("\n  Введите текстом путь к папке или файлу.", ConsoleColor.Cyan);
            ConsoleExt.WriteLine("  (К примеру C:/Program Files/ или D:/)", ConsoleColor.DarkGray);
            _fileCreatePath = Console.ReadLine(); 

            BeginSteps();

        }

        private void BeginSteps()
        {
            SetInfo();
            GetStepDir();
            SetOrder();
            SetResult();
            ShowList();
        }
        private void SetInfo()
        {
            Console.Clear();
            Console.WriteLine("\n  --[PathBuilder v0.9]--");
            //На всякий случай, если пустая строка то начать с момента ввода
            if (_fileCreatePath == "") GetStart();
            ConsoleExt.WriteLine(" \n Куда перейти дальше?\n", ConsoleColor.Red);

        }
        private void GetStepDir()
        {
            _folderIndex = 0;

            var directoryInfo = new DirectoryInfo(_fileCreatePath);
            // для папок
            foreach (var dirs in directoryInfo.GetDirectories())
            {
                _folderIndex++;
                dirList.Add(new FilePathListConstructor() { Id = _folderIndex, Name = dirs.Name, Type = "Dir " });
            }
            // для файлов
            foreach (var files in directoryInfo.GetFiles())
            {
                _folderIndex++;
                fileList.Add(new FilePathListConstructor() { Id = _folderIndex, Name = files.Name, Type = "File" });
            }
        } 

        private void SetOrder()
        {
            dirList = dirList.OrderBy(ob => ob.Name).ToList();
            fileList = fileList.OrderBy(ob2 => ob2.Name).ToList();
        }

        private void SetResult()
        {
            foreach (var names in dirList)
            {
                resultList.Add(names);
            }

            foreach (var names2 in fileList)
            {
                resultList.Add(names2);
            }
        }
        public void ShowList()
        {
            foreach (var finder in resultList)
            {
                ConsoleExt.WriteSelect(finder.Id);  
                switch (finder.Type)
                { 
                    case "Dir ":
                        ConsoleExt.Write($"|{ finder.Type}", ConsoleColor.DarkGray);
                        break;
                    case "File":
                        ConsoleExt.Write($"|{ finder.Type}", ConsoleColor.DarkCyan);
                        break;
                }
                Console.Write($"| {finder.Name}\n");
            }
             
            try
            {
                int sel = int.Parse(Console.ReadLine());
                var result = resultList[sel - 1];
                switch (result.Type)
                {
                    //Конструктор пути к файлу
                    case "Dir ":
                        _fileCreatePath += result.Name + "/";
                        fileList.Clear();
                        dirList.Clear();
                        resultList.Clear();
                        BeginSteps();
                        break;

                    case "File":
                        _fileCreatePath += result.Name;
                        Console.Clear();
                        Console.Write($"{_fileCreatePath}\n");
                        SelectTextWork _textWork = new SelectTextWork(_fileCreatePath);
                        _textWork.SelectWork();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Error in ShowList");
                Console.ReadLine();
            }
        }

       
       

    }
}

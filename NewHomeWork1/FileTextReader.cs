using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace NewHomeWork1
{
    class FileTextReader
    {
        private string TextInFile;
        private string backupFile = "./BackupText.txt"; 


        private string filepath;
        public void TextReader(string pathToFile)
        {
            filepath = pathToFile;
            if (pathToFile == "./WorkText.txt")
            {
                ConsoleExt.WriteLine($"  Путь к файлу передан: WorkText.txt "); //инфа на всякий случай
            }
            else
            {
                ConsoleExt.WriteLine($"  Путь к файлу передан: {pathToFile} ");
            }

            Backup(pathToFile);
            ReadText(); 
            NextStep();


        }
        //Читалка текста
        void ReadText()
        {
            DirectoryInfo dirinfo = new DirectoryInfo(filepath);
            try
            {
                using(StreamReader sr = new StreamReader(filepath))
                {
                    TextInFile = sr.ReadToEnd();
                }
            }
            catch
            {
                ConsoleExt.WriteLine("  Ошибка чтения", ConsoleColor.Red);
            }

        }
        // Для удобства оставил выбор тут
        public void NextStep()
        {
            TextMethods.DeleteInText deleteText = new TextMethods.DeleteInText();
            TextMethods.InfoText infoText = new TextMethods.InfoText();
            TextMethods.ReverceText ReverceText = new TextMethods.ReverceText();

            short idSelect = 0;
            ConsoleExt.WriteLine("\n\n Итак, как поступим дальше?\n");
            ConsoleExt.WriteSelect(1); ConsoleExt.WriteLine("Удалить символ",ConsoleColor.Gray);
            ConsoleExt.WriteSelect(2); ConsoleExt.WriteLine("Удалить слово", ConsoleColor.Gray);
            ConsoleExt.WriteSelect(3); ConsoleExt.WriteLine("Ввести каждое 10-ое слово + инфа", ConsoleColor.Gray);
            ConsoleExt.WriteSelect(4); ConsoleExt.WriteLine("Реверс третьего предложения\n ", ConsoleColor.Gray); 
            ConsoleExt.WriteSelect(0); ConsoleExt.WriteLine("Выйти из приложения\n ", ConsoleColor.DarkGray);
            try
            {
                idSelect = Convert.ToInt16(Console.ReadLine());
                switch (idSelect)
                {
                    case 0:
                        break;
                    case 1:
                        deleteText.DeleteMethod(TextInFile, filepath, 1);
                        NextStep();
                        break;

                    case 2:
                        deleteText.DeleteMethod(TextInFile, filepath, 2);
                        NextStep();
                        break;
                    case 3:
                        infoText.GetInfo(TextInFile);
                        NextStep();
                        break;
                    case 4:
                        ReverceText.Reverce(TextInFile);
                        NextStep();
                        break;
                    default:
                        ConsoleExt.Clear();
                        ConsoleExt.WriteLine("Не правильный выбор...");
                        NextStep();
                        break;
                }

            }
            catch
            {
                Console.WriteLine(" Нажал ентер значит, при пустом выборе значит, да?)\n  ");
                Console.ReadKey();
                NextStep();
            }
            return;

            
        }
        //бекап
        public void Backup(string originalFile)
        {           
            //Создание бекапа
            FileInfo original = new FileInfo(originalFile);
            FileInfo backup = new FileInfo(backupFile);
            try
            {
                using (FileStream fs = backup.Create()) { } //источник
                if (File.Exists(backupFile)) { backup.Delete(); } //если существует то удалить :3

                //Копирование...
                original.CopyTo(backupFile);
                ConsoleExt.Write($"\tКопия создана в корневой папке (*{backupFile})", ConsoleColor.DarkGray);

            }
            catch (IOException e)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n Скорее всего не существует файл, но на всякий\n ERROR:\n", e);
                Console.Read();
            }

        }
    }
}

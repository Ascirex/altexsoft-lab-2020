using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace qwe
{

    class TextModif
    {
        public string ReadyText { get; set; } //текст для изменений
        public string getedTextPath { get; set; } // путь к файлу
        int selecID = 0;
        public TextModif(string fileText, string getTextPath)
        {
            ReadyText = fileText;
            getedTextPath = getTextPath;
        }

        public void BeginChanges()
        {
            Console.Clear();
            string _backupFile = @"./backupTextFile.txt";

            // Create 1 static backup 
            FileInfo FFInf = new FileInfo(getedTextPath);
            FileInfo BFInf = new FileInfo(_backupFile);
            try
            {
                using (FileStream fs = BFInf.Create()) { } //источник
                if (File.Exists(_backupFile)) { BFInf.Delete(); } //если существует то удалить :3

                //Копирование...
                FFInf.CopyTo(_backupFile);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n>File: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"({getedTextPath})\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(">copied to this directory:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" ({_backupFile})\n");

                Console.ReadLine();
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR:\n", e);
                Console.Read();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  {Text.FType} {getedTextPath}\n {Text.ChangerT_1}");
            Console.ForegroundColor = ConsoleColor.White;
            
            return;
            // Методы
            try
            {
                selecID = Convert.ToInt32(Console.ReadKey().Key);

            }
            catch
            {
                Console.WriteLine($"{Text.Select1Err}");
                Console.ReadKey();
                BeginChanges();
            }


            Regex regTXT = new Regex(@"do\w*");

            MatchCollection methodTEXT = regTXT.Matches(ReadyText);

            for (int i = 0; i < methodTEXT.Count; i++)
            {
                Console.WriteLine(methodTEXT[i].Value);
            }
            Console.WriteLine();
        } 
        void DeleteSymbolInTxt()
        {
            // Удалить указанную строку\символ
        }
        void InfoInTxt()
        {
            // Вывести каждое 10 слово через запятую, сколько слов в тексте
        }
        void ReverceText()
        {
            // Реверсировать 3 предложение, буквы в обратном порядке.
        }
    }

    } 

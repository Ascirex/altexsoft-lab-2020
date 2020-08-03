using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
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
            #region backup code heare
            FileInfo FFInf = new FileInfo(getedTextPath);
            FileInfo BFInf = new FileInfo(_backupFile);
            try
            {
                using (FileStream fs = BFInf.Create()) { } //источник
                if (File.Exists(_backupFile)) { BFInf.Delete(); } //если существует то удалить :3

                //Копирование...
                FFInf.CopyTo(_backupFile);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{Text.FType}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"({getedTextPath})\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Text.FCopy}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" ({_backupFile})");

            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR:\n", e);
                Console.Read();
            }
            #endregion
            selectorV1(); // Выбор
        }


        void selectorV1()
        {            // Методы
            Console.WriteLine($"\n  {Text.ChangerT_1}");
            Console.ForegroundColor = ConsoleColor.White;
            CyanText("\n  [1]");
            Console.Write($"{Text.Tselect1_1}");
            CyanText("\n  [2]");
            Console.WriteLine($"{Text.Tselect1_2} ");
            CyanText("  [3]");
            Console.WriteLine($"{Text.Tselect1_3} ");
            CyanText("  [4]");
            Console.WriteLine($"{Text.Tselect1_4} ");
            try
            {
                selecID = Convert.ToInt32(Console.ReadKey().Key);

                switch (selecID)
                {
                    case 49: // Удалить указанный символ
                        Console.Clear();
                        DeleteSymbolInTxt();
                        break;
                    case 50: // Удалить указанную строку 
                        Console.Clear();
                       DeleteWordinText();
                        break;
                    case 51:// Вывести каждое 10 слово через запятую, сколько слов в тексте
                        Console.Clear();
                        InfoInTxt();
                        break;
                    case 52:// Реверсировать 3 предложение, буквы в обратном порядке.
                        Console.Clear();
                        ReverceText();
                        break;
                    default:
                        Console.Clear();
                        CyanText($"\n {Text.Select}\n");
                        selectorV1();
                        break;
                }
            }
            catch
            {
                Console.WriteLine($"{Text.Select1Err}");
                Console.ReadKey();
                BeginChanges();
            }

        }
        void DeleteSymbolInTxt() // Удалить указанный символ (регекс)
        {
            Console.WriteLine($" {Text.TdelS}");
            Console.WriteLine($"{Text.T1S}");
            try
            {
                Console.Write("  > ");
                char _entrText = Console.ReadKey().KeyChar;
                CyanText($"\n\n Deleted Char: \"{_entrText}\"\n");
                    ReadyText = Regex.Replace(ReadyText, $@"[{_entrText}]", "");
                    Console.WriteLine(ReadyText);
                    WriterFile();
            }
            catch
            {
                Console.WriteLine($"ERR: {Text.TNF}") ;
            }
            choseN();
        }

        void DeleteWordinText()
        {
            Console.WriteLine($"{Text.TdelT}");
            try
            {
                string entText = Console.ReadLine();
                if (ReadyText.Contains(entText))
                {
                    ReadyText = ReadyText.Replace(entText, "");
                    Console.WriteLine(ReadyText); 
                    choseN();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\n {Text.TNF1} ");
                    choseN(); 
                }
               
            }
            catch {
                Console.WriteLine("Error in DeleteWordinText");
                Console.ReadKey();
                choseN();
            }
            
        }


        void choseN()
        { 
            Console.WriteLine($"\n{Text.Next}?\n  [1] {Text.Next1}\n  [2] {Text.Exit}\n");
            try //Text.Select1Err
            {
               int k= Console.ReadKey().KeyChar;
                switch(k){
                    case 49:
                        BeginChanges();
                        break;
                    case 50:

                        return;
                    default:
                        Console.WriteLine("\n" + Text.Select1Err); Console.ReadKey(); Console.Clear(); choseN();
                        break;
                }

            }
            catch
            {
                Console.WriteLine("\n"+Text.Select1Err);Console.ReadKey();Console.Clear(); choseN();
            }

        }

        void InfoInTxt()
        {
            string[] masSS = ReadyText.Split(new char[] { ' ', '?', '!', '.', ';', ':', ',', '\r', '\n', '(', ')', '\"' },StringSplitOptions.RemoveEmptyEntries);
 
                for (int i = 0; i < masSS.Length; i+=10)
                {
                if (i < masSS.Length)
                    Console.Write(masSS[i]+", "); 
                if (i >= masSS.Length-10)
                    Console.WriteLine(masSS[i] + ".");
                }

           CyanText($"\n{Text.Info1}: {masSS.Length}");
            choseN();
        }
    
        string  ReverceMatched(Match x)
        {
            string xRevers = new string(x.Value.Reverse().ToArray()) ; 
            return xRevers;
        }

        void ReverceText()
        {
            //var s = ReadyText.Split('.');
            //var s1 = s[2].Split(new char[] { ' ', '?', '!', '.', ';', ':', ',', '\r', '\n', '(', ')', '\"' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var r in s1)
            //{
            //    var a = r.Reverse().ToArray() ;
            //    Console.WriteLine(a);
            //}
          
            var textReverce = ReadyText.Split(new char[] { '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var endSymbolIndex = ReadyText.LastIndexOf(textReverce[2])-1;
            var lastSymbol = ReadyText[endSymbolIndex];
            string a = Regex.Replace(textReverce[2], $@"\w(?<!\d)[\w'-]*",ReverceMatched );

            Console.WriteLine(a+lastSymbol);


            Console.ReadKey();



            choseN();
        }
        // Тестовая идея
        void CyanText(string a)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(a);
            Console.ForegroundColor = ConsoleColor.White;
        }
 
        public void WriterFile() //открытие файла, передать сюда filePathText
        {
            DirectoryInfo dirinfo = new DirectoryInfo(getedTextPath);
            try
            {
                using (StreamWriter sr = new StreamWriter(getedTextPath))
                {
                    sr.Write(ReadyText);
                }
                Console.WriteLine("\n >File Saved...");
            }
            catch
            {
                Console.WriteLine("ERROR in writer");

                Console.ReadKey();
            }
        }

    }
}
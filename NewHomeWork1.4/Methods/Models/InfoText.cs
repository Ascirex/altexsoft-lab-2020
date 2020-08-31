using System;
using System.Collections.Generic;
using System.Text;

namespace NewHomeWork1._4.Methods
{
    internal class InfoText
    {
        public void GetInfo(string path)
        {
            string text = FileTextReader.TextReader(path);
            ConsoleExt.Clear();
            string[] changeText = text.Split(new char[] {' ', '?', '!', '.', ';', ':', ',', '\r', '\n', '(', ')', '\"'},
                StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < changeText.Length; i += 10)
            {
                if (i < changeText.Length)
                    Console.Write(changeText[i] + ", ");
                if (i >= changeText.Length - 10)
                    Console.WriteLine(changeText[i] + ".");
            }

            ConsoleExt.WriteLine($"\n Инфо:  {changeText.Length} слов в тексте.");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;


namespace NewHomeWork1.TextMethods
{
    class InfoText //задание 2. Сколько слов, и каждое 10ое слово через запятую.
    {
        public void GetInfo(string text)
        {

            ConsoleExt.Clear();
            string[] changeText = text.Split(new char[] { ' ', '?', '!', '.', ';', ':', ',', '\r', '\n', '(', ')', '\"' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < changeText.Length; i += 10)
            {
                if (i < changeText.Length)
                    Console.Write(changeText[i] + ", ");
                if (i >= changeText.Length - 10)
                    Console.WriteLine(changeText[i] + ".");
            }

            ConsoleExt.WriteLine($"\n Инфо:  {changeText.Length} слов в тексте.");
            Console.ReadLine();
        }
    }
}

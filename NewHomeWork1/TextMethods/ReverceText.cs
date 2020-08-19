using System;
using System.Collections.Generic; 
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;




namespace NewHomeWork1.TextMethods
{
    class ReverceText //задание 3. Реверсировать 3 строчку.
    {
        public void Reverce(string ReadyText)
        {
            var textReverce = ReadyText.Split(new char[] { '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var endSymbolIndex = ReadyText.LastIndexOf(textReverce[2]) - 1;
            var lastSymbol = ReadyText[endSymbolIndex];
            string a = Regex.Replace(textReverce[2], $@"\w(?<!\d)[\w'-]*", ReverceMatched); 
            Console.WriteLine(a + lastSymbol);
             
            Console.ReadKey();

        }
        string ReverceMatched(Match x)
        {
            string xRevers = new string(x.Value.Reverse().ToArray());
            return xRevers;
        }
    }
}

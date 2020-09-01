using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NewHomeWork1._4.Methods.Models
{
    internal class ReverceText
    {
        public void Reverce(string pathF)
        {
            Console.Clear();
            var ReadyText = FileTextReader.TextReader(pathF);

            var textReverce = ReadyText.Split(new char[] { '?', '!', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var endSymbolIndex = ReadyText.LastIndexOf(textReverce[2]) - 1;
            var lastSymbol = ReadyText[endSymbolIndex];
            var a = Regex.Replace(textReverce[2], $@"\w(?<!\d)[\w'-]*", ReverceMatched);
            Console.WriteLine(a + lastSymbol);

            Console.ReadKey();

        }
        string ReverceMatched(Match x)
        {
            var xRevers = new string(x.Value.Reverse().ToArray());
            return xRevers;
        }
    }
}

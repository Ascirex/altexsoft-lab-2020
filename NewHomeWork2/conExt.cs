using System;
using System.Collections.Generic;
using System.Text;

namespace NewHomeWork2
{
     static class conExt
    {
        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);

        }
        public static void Write(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);

        }
        public static void Clear()
        {
            Console.Clear();
        }

        public static  void Select(int id)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   [");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(id);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace NewHomeWork1
{
    static class ConsoleExt
    {
        //Тут банальные врайтлайны с измененным цветом текста

        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Write(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void WriteSelect(int x)
        { 
            int maxPaddingLenght = 7; 
            int padding = maxPaddingLenght - x.ToString().Length; 
            Write("[".PadLeft(padding+1)) ; 
            Write(x.ToString(), ConsoleColor.Cyan); Write("] "); 

        }
             
        public static void Clear()
        {
            Console.Clear();
        }
    }
}

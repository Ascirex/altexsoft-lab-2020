using System; 
using System.Text;

namespace NewHomeWork1
{
    static class ConsoleExt
    {
        //Тут банальные врайтлайны с измененным цветом текста

        public static void WriteLine( string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine( text);
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
            if (x < 10)             { Write("   ["); }
            if (x >= 10 && x < 100) { Write("  [");  }
            if (x > 100)            { Write(" [");   }
            Write(x.ToString(), ConsoleColor.Cyan); Write("] ");
        }
             
        public static void Clear()
        {
            Console.Clear();
        }
    }
}

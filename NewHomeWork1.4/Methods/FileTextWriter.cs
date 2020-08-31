using System;
using System.IO;

namespace NewHomeWork1._4.Methods
{
    internal static class FileTextWriter
    {
       public static void Save( string pathToFile, string savedTxt)
         {
            if (File.Exists(pathToFile))
            {
                using (var srw = new StreamWriter(pathToFile))
                {
                    srw.Write(savedTxt);
                }
                ConsoleExt.WriteLine(" \n  Файл сохранён...",ConsoleColor.DarkGray);
            } 
         }
    }
}

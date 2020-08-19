using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewHomeWork1
{
    class FileTextWriter
    {
         
        public void SaveText(string savedTXT, string pathfile)
        {
            DirectoryInfo dir = new DirectoryInfo(pathfile);
            try
            {
                using (StreamWriter srw = new StreamWriter(pathfile))
                {
                    srw.Write(savedTXT);
                }
                Console.WriteLine(" Файл сохранён...");
            }
            catch
            {
                Console.WriteLine(" Ошибка в методе сохранения");
                Console.ReadKey();
            }

        }
    }
}

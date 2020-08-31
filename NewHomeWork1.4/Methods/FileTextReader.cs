using System;
using System.IO;

namespace NewHomeWork1._4.Methods
{
   internal static class FileTextReader
    { 

        public static string TextReader(string pathToFile)
        {
            try
            {
                string _textInFile;
                using (var sr = new StreamReader(pathToFile))
                {
                    _textInFile = sr.ReadToEnd();
                }

                return _textInFile;
            }
            catch
            {
              return   "  Ошибка чтения файла" ;
            }
            

        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NewHomeWork1._4.Methods
{
   internal class DeleteSymbol
   {
       private string _filePath;
        public void EditSymbol(int idEditor, string Path)
        {
            _filePath = Path;
            Console.Clear();
            var fileText = FileTextReader.TextReader(_filePath);
            FileBackup.Backup(_filePath);

            UserIteraction(fileText, idEditor);
            ConsoleExt.WriteLine(" Нажмите любую кнопку чтобы продолжить.", ConsoleColor.Cyan);
            Console.ReadKey();
        }

        private void UserIteraction(string textFile, int id)
        {
            ConsoleExt.Write("\n Какой символ удалить из файла?\n Символ: ", ConsoleColor.Yellow);
            try
            {
                string x = null;
                string choice = null;
                if (id == 1)
                {
                    char x1 = Console.ReadKey().KeyChar;
                    x = Convert.ToString(x1);
                    choice = "Символ";
                    if (textFile.Contains(x))
                    {
                        textFile = Regex.Replace(textFile, $@"[{x}]", "");
                    }
                    else
                    {
                        ConsoleExt.WriteLine("\n Увы, но такого символа уже нет с нами... ", ConsoleColor.Cyan);
                    }
                }
                if (id == 2)
                {
                    string x2 = Console.ReadLine();
                    x = x2; choice = "Слово";
                    textFile = textFile.Replace(x2, "");
                }

                FileTextWriter.Save(_filePath, textFile);
                ConsoleExt.WriteLine($"\n{textFile}\n");
            }
            catch
            {
                ConsoleExt.WriteLine(" Ошибка при удалении символа", ConsoleColor.Magenta);
            }
        }
    }
}

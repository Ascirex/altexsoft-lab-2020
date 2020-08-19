using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NewHomeWork1.TextMethods
{
    class DeleteInText 
    {
        // Удаление символа, либо слова
        FileTextWriter save = new FileTextWriter(); 
        public void DeleteMethod(string textFile, string textpath, int id)
        {
            ConsoleExt.Clear();
            ConsoleExt.Write($" Окей. И  что тут у нас поддастся всемирному геноциду?)  \n И это будет:\n  >", ConsoleColor.Gray);
            try
            {

                string x  =null; 
                string choice = null;
                if (id == 1) 
                {
                char x1 = Console.ReadKey().KeyChar;
                    x = Convert.ToString( x1);
                    choice = "Символ";
                    if (textFile.Contains(x))
                    {
                        textFile = Regex.Replace(textFile, $@"[{x}]", "");
                    }
                    else 
                    {
                        ConsoleExt.WriteLine("Увы, но такого символа уже нет с нами... ");
                    }
                }
                if (id == 2)
                {
                    string x2 = Console.ReadLine();
                    x = x2; choice = "Слово";
                    textFile = textFile.Replace(x2, ""); 
                }
                Print(textFile, choice, x);
                save.SaveText(textFile,textpath);
            }
            catch
            {
                ConsoleExt.WriteLine(" Ошибка при удалении символа", ConsoleColor.Magenta);
            }
             

        }
        void Print(string textFile, string choice, string x)
        {
            ConsoleExt.WriteLine($"\n{textFile}\n");
            ConsoleExt.Write($"\n {choice} для удаления: ", ConsoleColor.DarkCyan);
            ConsoleExt.Write($"{x}\n", ConsoleColor.Green);

        }
         
    }
}

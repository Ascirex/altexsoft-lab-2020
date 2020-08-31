using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using NewHomeWork1._4.Methods.Models;

namespace NewHomeWork1._4.Methods
{
    internal class SelectTextWork
    {
        DeleteSymbol deleteSymbol= new DeleteSymbol();
        InfoText infoText = new InfoText();
        ReverceText reverceText = new ReverceText();

        private string _filePath;
        public SelectTextWork(string filepath)
        {
            _filePath = filepath;
        }
        
        public void SelectWork()
        { 
            ConsoleExt.Clear();
            SetSelector(); 
         
        }

   
        private void SetSelector()
        {
            ConsoleExt.WriteLine($" Файл для обработки: {_filePath}\n", ConsoleColor.DarkGray);
            ConsoleExt.WriteLine("\n Как поступить дальше? Выберите пожалуйста следующее действие:\n");
            ConsoleExt.WriteSelect(1);
            ConsoleExt.Write("Удалить символ;\n");
            ConsoleExt.WriteSelect(2);
            ConsoleExt.Write("Удалить строку;\n");
            ConsoleExt.WriteSelect(3);
            ConsoleExt.Write("Вывести каждое 10-ое слово + инфа;\n");
            ConsoleExt.WriteSelect(4);
            ConsoleExt.Write("Реверс третьего предложения;\n");
            ConsoleExt.WriteSelect(0);
            ConsoleExt.Write("Выйти из приложения.\n",ConsoleColor.DarkCyan);

            try
            {
                switch (int.Parse(Console.ReadKey().KeyChar.ToString()))
                {
                    case 0: 
                        ConsoleExt.Clear(); 
                        break;

                    case 1:
                        deleteSymbol.EditSymbol(1, _filePath); 
                        SelectWork();
                        break;

                    case 2:
                        deleteSymbol.EditSymbol(2, _filePath);
                        SelectWork();
                        break;

                    case 3:
                        infoText.GetInfo(_filePath);
                        SelectWork();
                        break;

                    case 4:
                        reverceText.Reverce(_filePath); 
                        SelectWork();
                        break;

                    default:
                        ConsoleExt.Clear();
                        ConsoleExt.WriteLine(" Пожалуйста, выберите из списка.", ConsoleColor.Yellow);
                        SetSelector();  
                        break; 
                }

            }
            catch
            {
                ConsoleExt.Clear();
                ConsoleExt.WriteLine(" Пожалуйста, воспользуйтесь цифрами. :)", ConsoleColor.Yellow);
                SetSelector(); 
            }
        }

      
    }
}

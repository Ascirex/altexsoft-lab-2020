using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewHomeWork1._4.Methods
{
    internal static class FileBackup
    {
        public static void Backup(string filepath)
        { 
            FileInfo original = new FileInfo(filepath);
            FileInfo backup = new FileInfo(Constants.BackupPath);
            try
            {
                using (FileStream fs = backup.Create()) { } //источник
                if (File.Exists(Constants.BackupPath)) { backup.Delete(); } //если существует то удалить :3

                //Копирование...
                original.CopyTo(Constants.BackupPath);
                ConsoleExt.Write($"\tКопия создана в корневой папке (*{Constants.BackupPath})\n ", ConsoleColor.DarkGray);

            }
            catch (IOException e)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n Скорее всего не существует файл, но на всякий\n ERROR:\n\n", e);
                Console.Read();
            }
        }
    }
}

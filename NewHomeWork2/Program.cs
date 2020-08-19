using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Cache;
using System.Text;

namespace NewHomeWork2
{
    // public class Person
    // {
    //    public string Name { get; set; }
    //    public int Age { get; set; } 
    // }

    class Program
    {
        static void Main(string[] args)
        {
            SetSettings();
            // var person = File.Exists("Test.json")?JsonConvert.DeserializeObject<Person>(File.ReadAllText("Test.json")):new Person
            // {
            //    Name = "SS",
            //    Age = 10

            // };  
            //  File.WriteAllText("Test.json", JsonConvert.SerializeObject(person));
            



            Console.WriteLine("End Programm");
            Console.ReadKey();
        }

        static void SetSettings()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "New homework №1 v0.3";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}

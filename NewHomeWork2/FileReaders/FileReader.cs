using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NewHomeWork2.FileReaders
{
    internal class FileReader<T> 
    {
        private readonly string _fileName;

        public FileReader(string fileName)
        {
            _fileName = fileName;
        }

        public List<T> Read()
        {
            if (!File.Exists(_fileName))
            {
                return new List<T>();
            }
          
            string jsonString = File.ReadAllText(_fileName);

            List<T> items = JsonConvert.DeserializeObject<List<T>>(jsonString);

            return items;
        }

        public void Write(List<T> items)
        {
            string jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);

            File.WriteAllText(_fileName, jsonString);
        }
   }
}

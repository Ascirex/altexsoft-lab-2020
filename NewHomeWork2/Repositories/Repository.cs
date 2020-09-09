using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NewHomeWork2.FileReaders;
using NewHomeWork2.Models;

namespace NewHomeWork2.Repositories
{
	internal abstract class Repository<T> 
		where T: BaseModel
	{
		private readonly FileReader<T> _fileReader;

		protected Repository(string fileName)
		{
			_fileReader = new FileReader<T>(fileName);
		}

		public List<T> GetAll()
		{ 
			List<T> items = _fileReader.Read();
			Console.WriteLine();
			return items;
		}

		public T GetById(int id)
		{
			T item = GetAll()
				.FirstOrDefault(recipe1 => recipe1.Id == id);
			return item;
		}

		public void Add(T value)
		{
			Random random = new Random();
			value.Id = random.Next();

			List<T> items = GetAll();
			items.Add(value);
			_fileReader.Write(items);
		}

		public void Update(T value)
		{
			List<T> items = GetAll();

			int index = items
				.FindIndex(item => item.Id == value.Id);
			items[index] = value;

			_fileReader.Write(items);
		}

		public void Delete(int id)
		{
			List<T> items = GetAll();

			int index = items.FindIndex(item => item.Id == id);
			items.RemoveAt(index);

			_fileReader.Write(items);
		}
    }
}
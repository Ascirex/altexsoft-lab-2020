using System;

namespace NewHomeWork2
{
	internal static class ConExt
	{
		public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(text);

		}

		public static void Write(string text, ConsoleColor color = ConsoleColor.White)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(text);

		}

		public static void Clear()
		{
			Console.Clear();
		}

		public static void WriteSelect(int id)
		{
			Console.Write(" [");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write(id);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("] ");
		}

		public static int ReadChoice()
		{
			var choice = Console.ReadLine();
			if (int.TryParse(choice, out int choiceInt))
			{
				return choiceInt;
			}
			else
			{
				WriteLine("Enter correct value:");
				return ReadChoice();
			}
		}
	}
}

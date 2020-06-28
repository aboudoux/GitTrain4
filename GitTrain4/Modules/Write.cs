using System;

namespace GitTrain4
{
	public static class Write
	{
		public static void Color(string data, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(data);
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
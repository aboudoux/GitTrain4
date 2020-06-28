using System;
using System.Reflection;

namespace GitTrain4 {
	class Program {
		static void Main(string[] args) 
		{
			Assembly.GetExecutingAssembly().RunModules();
			
			Console.WriteLine("Appuyez sur une touche pour terminer");
			Console.ReadLine();
		}
	}
}

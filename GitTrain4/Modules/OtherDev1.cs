using System;

namespace GitTrain4
{
	public class OtherDev1 : IModule
	{
		public void Run()
		{
			Write.Color("Otherdev premier module", ConsoleColor.Blue);
		}
	}
}
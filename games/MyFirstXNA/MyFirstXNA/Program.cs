using System;

namespace MyFirstXNA
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main( string[] args )
		{
			//using( TestsForFun.TestsMain game = new TestsForFun.TestsMain() )
			using( Game1 game = new Game1() )
			{
				game.Run();
			}
		}
	}
}


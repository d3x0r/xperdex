using System;

namespace TestsForFun
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TestsMain game = new TestsMain())
            {
                game.Run();
            }
        }
    }
}


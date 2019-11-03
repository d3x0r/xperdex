using System;

namespace CameraMovement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Movement game = new Movement())
            {
                game.Run();
            }
        }
    }
}


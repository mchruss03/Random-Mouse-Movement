using System;

using System.Threading;
using System.Media;
using System.Windows.Forms;

//
//  Application Name: Drunk Mouse Movement
//  Description: Application that generates erratic mouse movements only when user is moving the mouse
//

namespace DrunkPC
{
    class Program
    {
        public static Random _random = new Random();

        /// <summary>
        /// Entry point for prank application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("DrunkMouse Prank Application by: Russell");

            // Create all threads that manipulate all of the inputs and outputs to the system
            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouseThread));

            // Start all of the threads
            drunkMouseThread.Start();

            Console.WriteLine("Terminating all threads");

            // Kill all threads and exit application
            //drunkMouseThread.Abort();
        }

        #region Thread Functions
        /// <summary>
        /// This thread will randomly affect the mouse movements to screw with the end user
        /// </summary>
        public static void DrunkMouseThread()
        {
            Console.WriteLine("DrunkMouseThread Started");

            int moveX = 0;
            int moveY = 0;

            while (true)
            {
                // Console.WriteLine(Cursor.Position.ToString());
                int oldXPos = Cursor.Position.X;
                int oldYPos = Cursor.Position.Y;
                Thread.Sleep(10);

                if (Cursor.Position.X != oldXPos || Cursor.Position.Y != oldYPos)
                {
                    // Generate the random amount to move the cursor on X and Y
                    moveX = _random.Next(20) - 10;
                    moveY = _random.Next(20) - 10;

                    // Change mouse cursor position to new random coordinates
                    Console.WriteLine("Cursor has moved.");
                    Cursor.Position = new System.Drawing.Point(
                        Cursor.Position.X + moveX,
                        Cursor.Position.Y + moveY);

                }

                Thread.Sleep(333);
            }
        }
        #endregion
    }
}
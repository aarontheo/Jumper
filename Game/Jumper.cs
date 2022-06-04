using System;
using System.Collections.Generic;

namespace Jumper
{
    public static class Jumper
    {
        private static String[] img = System.IO.File.ReadAllLines(@"jumper.txt");
        /// <summary>
        /// Draws the jumper with a number of lines equal to lines subtracted,
        /// displaying as blank.
        /// </summary>
        /// <param name="lines">The number of lines to leave blank, defaults to 0</param>
        public static void DrawLines(int lines = 0)
        {
            for (int i = 0; i < img.GetLength(0); i++)
            {
                if (i < lines)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(img[i]);
                }
            }
        }
    }
}

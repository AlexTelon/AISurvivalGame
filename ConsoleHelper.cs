using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalAIGame
{
    public static class ConsoleHelper
    {
        internal static void HorizontalBar(int x, int max)
        {
            double MAX_WIDTH = 40;
            double MAX_VALUE = max;

            var nrOfBars = (x / MAX_VALUE) * MAX_WIDTH;

            var orig = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < nrOfBars; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
            Console.ForegroundColor = orig;
        }
    }
}

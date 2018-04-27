using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SurvivalAIGame
{
    internal class UserInput : IInput
    {
        public int Get()
        {
            int returnValue = 0;
            while (!int.TryParse(Console.ReadLine(), out returnValue)) { }
            return returnValue;
        }
    }
}

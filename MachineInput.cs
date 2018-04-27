using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalAIGame
{
    class MachineInput : IInput
    {
        private static Random Rnd = new Random();

        public int Get()
        {
            // let the machine anwer questions according to some rule
            return Rnd.Next(1, 3);
        }
    }
}

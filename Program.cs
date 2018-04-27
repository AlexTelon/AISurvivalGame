using System;

namespace SurvivalAIGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // start a game and give it a input device
            var game = new Game(new UserInput());

            Console.WriteLine("Starting game..");

            game.Start();
        }
    }
}

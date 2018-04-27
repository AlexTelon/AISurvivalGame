using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace SurvivalAIGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var loadPreviousGame = false;
            Game game;
            if (loadPreviousGame)
            {
                // load game if possible:
                string input = File.ReadAllText("game.txt");
                game = JsonConvert.DeserializeObject<Game>(input);
            } else
            {
                game = new Game();
            }

            //game.Input = new UserInput();
            game.Input = new MachineInput();

            Console.WriteLine("Starting game..");

            game.Start();

            // save game
            string output = JsonConvert.SerializeObject(game);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"game.txt"))
            {
                file.WriteLine(output);
            }

            Console.ReadLine();
        }
    }
}

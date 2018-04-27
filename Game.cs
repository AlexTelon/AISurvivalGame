using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalAIGame
{
    class Game
    {
        // 1 Food per worker per day
        private int Food
        {
            get => _food;
            set
            {
                _food = value;
                if (_food <= 0)
                {
                    Dead = true;
                }
            }
        }
        private int _food = 10;
        private int FoodGain = 1;

        // 1 Coin buys 1 food
        private int Coin = 100;
        private int CoinGain = 10;

        // Workers can gather stuff
        private int Workers = 1;

        private bool Dead = false;

        private IInput Input;

        private int Turn = 1;

        private List<string> TurnOptions = new List<string>();


        internal Game(IInput input)
        {
            Input = input;

            TurnOptions.Add("Put worker on food");
            TurnOptions.Add("Put worker on coin");
        }

        internal void Start()
        {
            while (!Dead)
            {
                NextTurn();
            }

            Console.WriteLine("You lost");
        }

        /// <summary>
        /// Runs through a round
        /// </summary>
        private void NextTurn()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Turn " + Turn);
            Console.WriteLine();
            Console.WriteLine("A new morning!");
            PrintCurrentState();
            Console.WriteLine();

            DoAction();
            WorkersGatherResources();
            WorkersEat();

            Turn++;
        }

        private void PrintCurrentState()
        {
            var max = Math.Max(Math.Max(Food, Coin), Workers);

            Console.Write("Food " + Food + ": ");
            ConsoleHelper.HorizontalBar(Food, max);

            Console.Write("Coin " + Coin + ": ");
            ConsoleHelper.HorizontalBar(Coin, max);

            Console.Write("Workers " + Workers + ": ");
            ConsoleHelper.HorizontalBar(Workers, max);

            Console.WriteLine();
        }

        /// <summary>
        /// The player gets one action per day
        /// </summary>
        private void DoAction()
        {
            Console.WriteLine("What action you want to perform?");

            for (int i = 0; i < TurnOptions.Count; i++)
            {
                Console.Write((i + 1) + ": " + TurnOptions[i] + " ");
            }
            Console.WriteLine();

            // we use 0 indexing internally, but the user sees options starting from 1
            var response = Input.Get() - 1;

            // gather food
            if (response == 1)
            {

            }
        }

        private void WorkersGatherResources()
        {
            Food += Workers;
        }

        private void WorkersEat()
        {
            Food -= Workers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SurvivalAIGame
{
    class Game
    {
        // 1 Food per worker per day
        private double Food
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
        private double _food = 10;
        private double FoodGain = 1;

        // 1 Coin buys 1 food
        private double Coin = 100;
        private double CoinGain = 10;

        // Workers can gather stuff
        private int Workers = 1;

        private bool Dead = false;

        private IInput Input;

        private int Turn = 1;

        private List<string> TurnOptions = new List<string>();

        public int MaxTurns = 100;

        internal Game(IInput input)
        {
            Input = input;

            TurnOptions.Add("Put worker on food");
            TurnOptions.Add("Put worker on coin");
        }

        internal void Start()
        {
            while (!Dead && Turn < MaxTurns)
            {
                NextTurn();
            }
            Console.Clear();
            Console.WriteLine();
            if (Dead)
            {
                Console.WriteLine("You lost");
            } else
            {
                Console.WriteLine("You won!");
            }

            Console.WriteLine("Coins at end: " + Coin);
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
            GatherResources();
            WorkersEat();

            Turn++;
        }

        private void PrintCurrentState()
        {
            var max = Math.Max(Math.Max(Food, Coin), Workers);

            Console.Write("Food {0:N1}: ", Food);
            ConsoleHelper.HorizontalBar(Food, max);

            Console.Write("Coin {0:N1}: ", Coin);
            ConsoleHelper.HorizontalBar(Coin, max);

            Console.Write("Workers {0:N1}: ", Workers);
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
            if (response == 0)
            {
                FoodGain += 1.1;
                Coin -= 10;
                Workers++;
            }

            if (response == 1)
            {
                CoinGain += 1;
                Coin -= 10;
                Workers++;
            }
        }

        private void GatherResources()
        {
            Food += FoodGain;
            Coin += CoinGain;
        }

        private void WorkersEat()
        {
            Food -= Workers;
        }
    }
}

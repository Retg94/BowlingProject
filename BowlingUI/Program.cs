using System;
using Library;

namespace BowlingUI
{
    class Program
    {
        public static bool menuRunning = true;
        static void Main(string[] args)
        {
            HandlePersonPoints.ReadFromFile();
            while(menuRunning)
            {
                PrintMainMenu();
            }
        }
        static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to this awesome bowlinggame. You can be up to 4 people.");
            Console.WriteLine("1. Add new player");
            Console.WriteLine("2. Start game");
            Console.WriteLine("3. Show highscore");
            Console.WriteLine("0. Exit game");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Current players: ");
            HandlePersonPoints.WriteAllPlayerNames();
            Console.WriteLine("");
            Console.WriteLine("Write your choice: ");
            int input = Helper.VerifyInt(Console.ReadLine());
            while(input<0 || input>3)
            {
                input = Helper.VerifyInt(Console.ReadLine());
            }

            switch (input)
            {
                case 1:
                    Console.Clear();
                    HandlePersonPoints.AddNewPlayer();
                    break;
                case 2:
                    Console.Clear();
                    int count = 0;
                    while(count<11)
                    {
                        HandlePersonPoints.PlayGame(count);
                        count++;
                    }
                    Console.WriteLine("Game is done. Calculating score...");
                    HandlePersonPoints.CalculateScore();
                    Helper.PressAnyKeyToContinue();
                    break;
                case 3:
                    Console.Clear();
                    HandlePersonPoints.ShowHighscoreList();
                    break;
                case 0:
                    Console.WriteLine("Exiting program..");
                    Helper.PressAnyKeyToContinue();
                    menuRunning = false;
                    break;
                default:
                    Console.WriteLine("Error. Exiting program.");
                    menuRunning = false;
                    break;
            }

        }


    }

}

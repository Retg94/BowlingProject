using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Library
{
    public class HandlePersonPoints
    {
        public static List<Person> Players = new List<Person>();
        public static List<PointHistory> History = new List<PointHistory>();
        public static void SaveHistoryToFile()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataFolder, "Highscore.csv");
            FileStream fsOverwrite = new FileStream(filePath, FileMode.Create);
            using (StreamWriter swOverwrite = new StreamWriter(fsOverwrite))
            {
                foreach (var score in History)
                {
                    swOverwrite.WriteLine(score.Name + ";" + score.Points);
                }
            }
        }
        public static void ReadFromFile()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataFolder, "Highscore.csv");
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) ;
            }
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    History.Add(new PointHistory(values[0], int.Parse(values[1])));
                }
            }
        }
        public static void AddNewPlayer()
        {
            if (Players.Count > 3)
            {
                Console.WriteLine("Maximum players is 4. Returning to menu.");
                Helper.PressAnyKeyToContinue();
                return;
            }
            Console.WriteLine("Enter name: ");
            string tmpName = Helper.VerifyString(Console.ReadLine());
            AddPlayerToList(tmpName);
        }
        public static void AddPlayerToList(string name)
        {
            Players.Add(new Person(name));
        }
        public static void TestMethodCheckActivePlayers()
        {

        }

        public static void ShowHighscoreList()
        {
            int index = 1;
            if(History.Count>0)
            {
                foreach(var score in History)
                {
                    Console.WriteLine($"{index}. Name: {score.Name}, Points: {score.Points}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Historylist is empty. ");
            }
            Helper.PressAnyKeyToContinue();
        }
        public static void CalculateScore()
        {
            Round tmp = new Round();
            foreach (var Player in Players)
            {
                Console.WriteLine($"{Player.Name}'s score is: {tmp.Score(Player)}");
                History.Add(new PointHistory(Player.Name, tmp.Score(Player)));
            }
            History = History.OrderBy(x => x.Points).ToList();
            History.Reverse();
            SaveHistoryToFile();
            ClearPlayerList();
        }
        private static void ClearPlayerList()
        {
            foreach(var player in Players)
            {
                player.FramePoints.Clear();
            }
            Players.Clear();

        }
        public static void InsertThrowsToList(int ballOne, int ballTwo, Person player)
        {
            Round tmp = new Round();
            tmp.Roll(ballOne, ballTwo, player);
        }
        public static void PlayGame(int count)
        {

            foreach (var Player in Players)
            {
                int ballOne = 0;
                int ballTwo = 0;
                if (count == 10)
                {
                    Points[] tmpArr = Player.FramePoints.ToArray();

                    if (tmpArr[9].SpareOrStrike == 'X')
                    {
                        Console.WriteLine($"Frame[{count + 1}]");
                        Console.WriteLine($"Player {Player.Name}'s turn [ExtraThrow 1]");
                        ballOne = Helper.VerifyInt(Console.ReadLine());
                        while (ballOne < 0 || ballOne > 10)
                        {
                            Console.WriteLine("Invalid input. There are only 10 pins and you can't knock down negative pins.");
                            ballOne = Helper.VerifyInt(Console.ReadLine());
                        }
                        if (ballOne != 10)
                        {
                            Console.WriteLine($"Player {Player.Name}'s turn [ExtraThrow 2]");
                            ballTwo = Helper.VerifyInt(Console.ReadLine());
                            while (ballTwo < 0 || ballTwo > (10 - ballOne))
                            {
                                Console.WriteLine($"Invalid input, you have {10 - ballOne} pins left and you can't knock down negative pins. ");
                                ballTwo = Helper.VerifyInt(Console.ReadLine());
                            }
                            InsertThrowsToList(ballOne, ballTwo, Player);
                        }
                        else if (ballOne == 10)
                        {
                            InsertThrowsToList(ballOne, ballTwo, Player);
                            Console.WriteLine($"Player {Player.Name}'s turn [ExtraThrow 2]");
                            ballOne = Helper.VerifyInt(Console.ReadLine());
                            while (ballOne < 0 || ballOne > 10)
                            {
                                Console.WriteLine("Invalid input. There are only 10 pins and you can't knock down negative pins.");
                                ballOne = Helper.VerifyInt(Console.ReadLine());
                            }
                            InsertThrowsToList(ballOne, ballTwo, Player);
                        }
                    }
                    else if (tmpArr[9].SpareOrStrike == '/')
                    {
                        Console.WriteLine($"Frame[{count + 1}]");
                        Console.WriteLine($"Player {Player.Name}'s turn [ExtraThrow 1]");
                        ballOne = Helper.VerifyInt(Console.ReadLine());
                        while (ballOne < 0 || ballOne > 10)
                        {
                            ballOne = Helper.VerifyInt(Console.ReadLine());
                        }
                        InsertThrowsToList(ballOne, ballTwo, Player);
                    }
                }
                else
                {
                    Console.WriteLine($"Frame[{count+1}]");
                    Console.WriteLine($"Player {Player.Name}'s turn");
                    Console.WriteLine("First throw: ");
                    ballOne = Helper.VerifyInt(Console.ReadLine());
                    while (ballOne < 0 || ballOne > 10)
                    {
                        Console.WriteLine("Invalid input. There are only 10 pins and you can't knock down negative pins.");
                        ballOne = Helper.VerifyInt(Console.ReadLine());
                    }
                    if (ballOne == 10)
                    {
                        InsertThrowsToList(ballOne, ballTwo, Player);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Second throw: ");
                        ballTwo = Helper.VerifyInt(Console.ReadLine());
                        while (ballTwo < 0 || ballTwo > (10 - ballOne))
                        {
                            Console.WriteLine($"Invalid input, you have {10-ballOne} pins left and you can't knock down negative pins. ");
                            ballTwo = Helper.VerifyInt(Console.ReadLine());
                        }

                    }
                    InsertThrowsToList(ballOne, ballTwo, Player);
                }

            }
            Console.Clear();
        }
        public static void WriteAllPlayerNames()
        {
            foreach (var player in Players)
            {
                Console.Write($"{player.Name}, ");
            }
            Console.WriteLine("");
        }

    }
}

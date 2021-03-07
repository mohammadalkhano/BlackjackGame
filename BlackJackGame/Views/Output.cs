using System;
using System.Collections.Generic;
using BlackJackGame.Models;

namespace BlackJackGame
{
    public class Output
    {
        public static void Logo()
        {
            var line = new string('=', 120);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{line}\n");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  #            Welcome to BlackJackGame!              #  *");
            Console.WriteLine("                             *  #           Press any key to continiue...           #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\n");
            Console.WriteLine($"{line}\n");
        }

        public static void LogoMeddelande(string meddelande)
        {
            var line = new string('=', 120);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{line}\n");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.Write("                             *  #");
            for (int i = 0; i < (51 - meddelande.Length) / 2; i++)
                Console.Write(" ");
            Console.Write(meddelande);
            for (int i = 0; i < (52 - meddelande.Length) / 2; i++)
                Console.Write(" ");
            Console.WriteLine("#  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\n");
            Console.WriteLine($"{line}\n");
        }
        public static void LogoMeddelandeDouble(string line1, string line2)
        {
            var line = new string('=', 120);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{line}\n");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.Write("                             *  #");
            for (int i = 0; i < (51 - line1.Length) / 2; i++)
                Console.Write(" ");
            Console.Write(line1);
            for (int i = 0; i < (52 - line1.Length) / 2; i++)
                Console.Write(" ");
            Console.WriteLine("#  *");
            Console.Write("                             *  #");
            for (int i = 0; i < (51 - line2.ToString().Length) / 2; i++)
                Console.Write(" ");
            Console.Write(line2);
            for (int i = 0; i < (52 - line2.ToString().Length) / 2; i++)
                Console.Write(" ");
            Console.WriteLine("#  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\n");
            Console.WriteLine($"{line}\n");
        }

        public static void PlayerInfoOutput(List<Player> players)
        {
            var line = new string('=', 120);

            Console.WriteLine($"Player Name\tBet\tScore\n");
            foreach (var player in players)
            {
                if (player.Name != "House")

                    Console.WriteLine($"{player.Name}\t{player.Bet}\t{player.Score}");
                else
                    Console.WriteLine($"{player.Name}\t\t{player.Bet}\t{player.Score}");
            }
            Console.WriteLine();
            Console.WriteLine(line);


        }

        public static void ShowMenu()
        {
            Logo();
            Agelimit();
            ShowTable();
        }

        private static void Agelimit()
        {
            var agelimit = false;
            while (!agelimit)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                       *=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");
                Console.WriteLine("                                       *=        Age limit  18 years!     =*");
                Console.WriteLine("                                       *=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\nTo move forwad to the game pleace enter your age: ");
                var check = int.TryParse(Console.ReadLine(), out var age);
                if (age >= 18 && check)

                {
                    Console.Clear();
                    agelimit = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    LogoMeddelande("Invalid input, try again");
                }

            }

        }

        public static void ShowTable()
        {
            Console.Clear();
            LogoMeddelande("Select Table");
            Console.WriteLine("\n [Table (1) \t Min-Bet: 100 \t Max-Bet 1000 ]\n [Table (2) \t Min-Bet: 100 \t Max-Bet 2000 ]\n [Table (3) \t Min-Bet: 200 \t Max-Bet 5000 ]\n [Table (4) \t Min-Bet: 1000 \t Max-Bet 10000]");

        }


        private static void PrintAt(int y, int x, string text)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write(text);
        }

        public static void PrintCard(int y, int x, int value, string symbol)
        {
            PrintAt(y++, x, "┌─────────┐");
            PrintAt(y++, x, $"│{value,-6}   │");
            PrintAt(y++, x, "│         │");
            PrintAt(y++, x, "│         │");
            PrintAt(y++, x, $"│    {symbol}    │");
            PrintAt(y++, x, "│         │");
            PrintAt(y++, x, "│         │");
            PrintAt(y++, x, $"│   {value,6}│");
            PrintAt(y++, x, "└─────────┘");
        }
        public static void DarkCard(int y, int x)
        {
            PrintAt(y++, x, "┌─────────┐");
            PrintAt(y++, x, "│LLLLLLLLL│");
            PrintAt(y++, x, "│LLLLLLLLL│");
            PrintAt(y++, x, "│LLLLLLLLL│");
            PrintAt(y++, x, "│LLLLLLLLL│");
            PrintAt(y++, x, "│LLLLLLLLL│");
            PrintAt(y++, x, "│LLLLLLLLL│");
            PrintAt(y++, x, "│LLLLLLLLL│");
            PrintAt(y++, x, "└─────────┘");
        }
    }
}
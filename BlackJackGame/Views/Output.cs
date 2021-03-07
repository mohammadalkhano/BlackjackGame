using System;
using System.Collections.Generic;
using BlackJackGame.Models;

namespace BlackJackGame
{
    public class Output
    {
        /// <summary>
        /// Log => Is printing  the Log 
        /// Zia
        /// </summary>
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
        /// <summary>
        /// LogoMeddelande => To print the one line masseges insaid av logo 
        /// Zia
        /// </summary>
        /// <param name="meddelande">Sending en string</param>
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

        /// <summary>
        /// LogoMeddelandeDouble => To print the two line masseges insaid av logo 
        /// </summary>
        /// <param name="line1">Sending the string massege in line one</param>
        /// <param name="line2">Sending the string massege in line one</param>
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


        /// <summary>
        /// LogoMeddelandeTripple => To print the three lines masseges insaid av logo 
        /// </summary>
        /// <param name="line1">Sending the string massege in line one</param>
        /// <param name="line2">Sending the string massege in line two</param>
        /// <param name="line3">Sending the string massege in line three</param>
        public static void LogoMeddelandeTripple(string line1, string line2, string line3)
        {
            var line = new string('=', 120);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{line}\n");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
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
            Console.Write("                             *  #");
            for (int i = 0; i < (51 - line3.ToString().Length) / 2; i++)
                Console.Write(" ");
            Console.Write(line3);
            for (int i = 0; i < (52 - line3.ToString().Length) / 2; i++)
                Console.Write(" ");
            Console.WriteLine("#  *");
            Console.WriteLine("                             *  #                                                   #  *");
            Console.WriteLine("                             *  # # # # # # # # # # # # # # # # # # # # # # # # # # #  *");
            Console.WriteLine("                             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\n");
            Console.WriteLine($"{line}\n");
        }
        /// <summary>
        /// Prints a score board in console with players
        /// name, bets and total score  /Philip
        /// </summary>
        /// <param name="players">List of players</param>
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
        }
        public static void ShowMenu()
        {
            Logo();
            Agelimit();
            ShowTable();
        }
        /// <summary>
        /// Agelimit => Asking for Age, Agelimit is 18 to play the game.
        /// Zia
        /// </summary>
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


        /// <summary>
        /// ShowTable => printig Tables informations
        /// Zia
        /// </summary>

        public static void ShowTable()
        {
            Console.Clear();
            LogoMeddelande("Select Table");
            Console.WriteLine("\n [Table (1) \t Min-Bet: 100 \t Max-Bet 1000 ]\n [Table (2) \t Min-Bet: 100 \t Max-Bet 2000 ]\n [Table (3) \t Min-Bet: 200 \t Max-Bet 5000 ]\n [Table (4) \t Min-Bet: 1000 \t Max-Bet 10000]");

        }

        /// <summary>
        /// This method was posted by Marcus in Discord
        /// Prints card to console
        /// </summary>
        /// <param name="y">y value</param>
        /// <param name="x">x value</param>
        /// <param name="text">Text to be printed</param>
        private static void PrintAt(int y, int x, string text)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write(text);
        }
        /// <summary>
        /// This method was posted by Marcus in Discord
        /// Prints card to console
        /// </summary>
        /// <param name="y">y value</param>
        /// <param name="x">x value</param>
        /// <param name="value">Cards value</param>
        /// <param name="symbol">Card symbol</param>
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
        /// <summary>
        /// Prints a card upside down (deales second card)
        /// Philip
        /// </summary>
        /// <param name="y">y value</param>
        /// <param name="x">x value</param>
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
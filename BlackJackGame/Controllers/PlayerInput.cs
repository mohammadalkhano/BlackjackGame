﻿using System;

namespace BlackJackGame
{
    public class PlayerInput
    {
        public int NumberOfPlayers { get; set; }
        public int ActiveTable { get; set; }
        public bool NewCard { get; set; }


        public static int InvalidInputCheck()
        {
            int parseOK;
            while (!Int32.TryParse(Console.ReadLine(), out parseOK))
            {
                Console.WriteLine("Invalid input, try again");
            }
            return parseOK;
        }
        public static int CheckMinMaxInput(int input, int min, int max)
        {

            while (input < min || input > max)
            {
                Console.WriteLine($"Please chose between {min} and  {max}");
                input = InvalidInputCheck();
            }

            return input;
        }

    }

}
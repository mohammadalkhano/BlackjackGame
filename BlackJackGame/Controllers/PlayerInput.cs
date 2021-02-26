using System;

namespace BlackJackGame
{
    public class PlayerInput
    {
        public int NumberOfPlayers { get; set; }
        public int ActiveTable { get; set; }
        public bool NewCard { get; set; }


        public int InvalidInputCheck()
        {
            int parseOK;
            while (!Int32.TryParse(Console.ReadLine(), out parseOK))
            {
                Console.WriteLine("Invalid input, try again");
            }
            return parseOK;
        }
        public bool CheckMinMaxInput(int input, int min, int max)
        {
            if (input >= min && input <= max)
                return true;
            else
                return false;
        }

    }

}
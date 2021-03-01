using System;

namespace BlackJackGame
{
    public class PlayerInput
    {
        public int NumberOfPlayers { get; set; }
        public int ActiveTable { get; set; }
        public bool NewCard { get; set; }

        /// <summary>
        /// Forces user to enter an int
        /// </summary>
        /// <returns>Int value</returns>
        public static int InvalidInputCheck()
        {
            int parseOK;
            while (!Int32.TryParse(Console.ReadLine(), out parseOK))
            {
                Console.WriteLine("Invalid input, try again");
            }
            return parseOK;
        }
        /// <summary>
        /// Forces user to enter an int between two given values
        /// </summary>
        /// <param name="input">User intput</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns></returns>
        public static int CheckMinMaxInput(int input, int min, int max)
        {
            //if (min > max)
            //{
            //    int temp = min;
            //    min = max;
            //    max = temp;
            //}
            while (input < min || input > max)
            {
                Console.WriteLine($"Please chose between {min} and  {max}");
                input = InvalidInputCheck();
            }

            return input;
        }

    }

}
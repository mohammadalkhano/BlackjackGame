using System;

namespace BlackJackGame
{
    public class PlayerInput
    {
        /// <summary>
        /// Forces user to enter an int
        /// Philip
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
        /// Philip
        /// </summary>
        /// <param name="input">User intput</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns>Int value between min and max</returns>
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
using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public static class BlackJack
    {
        /// <summary>
        /// Asks user to select a table. Each tables has own rules for min and max bet
        /// </summary>
        /// <returns>List containing min and max value</returns>
        public static List<int> SelectTable()
        {
            Console.WriteLine();
            var list = new List<int>();
            switch (PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 4))
            {
                case 1:
                    list.Add(100);
                    list.Add(1000);
                    break;
                case 2:
                    list.Add(100);
                    list.Add(2000);
                    break;
                case 3:
                    list.Add(200);
                    list.Add(5000);
                    break;
                case 4:
                    list.Add(1000);
                    list.Add(10000);
                    break;
            }
            return list;
        }
    }
}

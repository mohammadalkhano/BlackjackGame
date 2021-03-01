using System;
using System.Collections.Generic;

namespace BlackJackGame
{



    public static class BlackJack
    {

        public static void CreatePlayer()
        {
            //throw new NotImplementedException();
        }


        public static int GiveCard(string openOrClose)
        {
            return 100;
        }

        public static void ResetDeck()
        {

            //throw new NotImplementedException();
        }

        public static void RunGame()
        {

        }


        public static int SeclectPlayers()
        {
            Console.WriteLine("How many players?");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 7);

        }

        public static List<int> SelectTable()
        {
            Console.WriteLine("Select table:");

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

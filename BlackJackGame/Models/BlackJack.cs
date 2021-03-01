using System;


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

        public static int SelectTable()
        {
            Console.WriteLine("Select table:");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 4);
        }
        public static bool PlayAgain()
        {
            
            return false;

        }
    }
}

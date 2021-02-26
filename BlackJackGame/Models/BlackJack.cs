using System;

namespace BlackJackGame
{
    public class BlackJack 
    {
        public void CreatePlayer()
        {
            throw new NotImplementedException();
        }

        public static int GiveCard(string openOrClose)
        {
            return 100;
        }

        public static void ResetDeck()
        {
            throw new NotImplementedException();
        }

        public void RunGame()
        {
            throw new NotImplementedException();
        }

        public static int SeclectPlayers()
        {
            Console.WriteLine("How many players?");            

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 4);

        }

        public static int SelectTable()
        {
            Console.WriteLine("Select table:");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 7);
        }
        public static bool PlayAgain()
        {
            return false;
        }
    }
}

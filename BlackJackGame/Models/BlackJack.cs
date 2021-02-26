using System;
namespace BlackJackGame
    {

    public static class BlackJack
        {
        public static void CreatePlayer()
            {
            throw new NotImplementedException();
            }

        public static void GiveCard()
            {
            throw new NotImplementedException();
            }

        public static void ResetDeck()
            {
            throw new NotImplementedException();
            }

        public static void RunGame()
            {
            
            }

        public static int SeclectPlayers(int nummber)
            {
            if (nummber < 1)
                {
                nummber = 1;
                Console.WriteLine("Nummber is too low. change it to 1 player");
                }
            if (nummber > 7)
                {
                nummber = 7;
                }

            return nummber;

            }

        public static int SelectTable(int table)
            {
            if (table <1)
                {
                table = 1;
                }
           else if (table > 4)
                {
                table = 4;
                }
            return table;
            }
        }
    }

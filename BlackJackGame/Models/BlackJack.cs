using System;
using System.Collections.Generic;

namespace BlackJackGame
    {
    public static class BlackJack
        {
        public static int GetCard(List<string> cards)
            {
            //var card = Cards.FirstOrDefault();
            //Cards.Remove(card);

            int score = 0;
            var card = cards[cards.Count - 1];

            var cardValue = card[0];

            if (cardValue == 'J' || cardValue == 'Q' || cardValue == 'K')
                score = 10;
            else if (cardValue == 'A')
                score = 11;
            else
                score = card[0];

            cards.Remove(card);

            return score;
            }

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

        /// <summary>
        /// Asks user to select how many players will be playing
        /// </summary>
        /// <returns> Int value </returns>
        public static int SeclectPlayers()
            {
            Console.Clear();
            Output.LogoMeddelande("How many players?");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(),1,7);
            }

        /// <summary>
        /// Asks user to select a table. Each tables has own rules for min and max bet
        /// </summary>
        /// <returns> List containing min and max value </returns>
        public static List<int> SelectTable()
            {
            Console.Clear();
            Output.LogoMeddelande("Select table:");
            Console.WriteLine("\n [Tabal (1) \t Min-Bet: 100 \t Max-Bet 1000 ]\n [Tabal (2) \t Min-Bet: 100 \t Max-Bet 2000 ]\n [Tabal (3) \t Min-Bet: 200 \t Max-Bet 5000 ]\n [Tabal (4) \t Min-Bet: 1000 \t Max-Bet 10000]");

            var list = new List<int>();

            switch (PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(),1,4))
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
namespace BlackJackGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Game
    {
        public static void RunGame()
        {
            var gameRunning = true;
            Output.ShowMenu();
            var activePlayers = Player.CreatePlayer(BlackJack.SeclectPlayers());
            Output.TableMenu();
            var table = BlackJack.SelectTable();
            //Tables();
            BlackJack.ResetDeck();
            

            while (gameRunning == true)
            {
                FirstGive(activePlayers, 100, 1000);
                PlayPlayers(activePlayers);
                PlayHouse(activePlayers);
                //if (activePlayers.Count > 1)//House is always playing
                //    PlayHouse(activePlayers);

                CheckWinners(activePlayers);

                gameRunning = PlayAgain();
            }

        }

        private static void FirstGive(List<Player> listOfPlayers, int minBet, int maxBet)
        {
            foreach (var player in listOfPlayers)  // FirstGive();
            {
                if (player.Name != "house")
                {
                    player.Bet = 0;
                    player.Bet = PlaceBet(minBet, maxBet);
                    player.Score += Deck.GetCard(Deck.newDeck);
                    player.Score += Deck.GetCard(Deck.newDeck);

                    if (player.Score == 21)
                    {
                        BlackJackWin(player.Name, player.Score);
                    }
                }
                    
            }

            foreach (var player in listOfPlayers)
            {
                if (player.Name == "house")
                {
                    player.Score += Deck.GetCard(Deck.newDeck);
                    player.Score += Deck.GetCard(Deck.newDeck);
                }
            }
        }
        private static void PlayPlayers(List<Player> listOfPlayers)
        {

            foreach (var player in listOfPlayers) //PlayPlayers();
            {
                if (player.Name != "house")
                {                    
                    while (player.Score < 21 || player.Stay == false)
                    {
                        Console.WriteLine("[1]Hit or [2]stay?");
                        Int32.TryParse(Console.ReadLine(), out int hitOrStay);
                        if (hitOrStay == 2)
                            player.Stay = true;
                        else
                            player.Score += Deck.GetCard(Deck.newDeck); ;
                    }
                }
            }
        }
        private static void PlayHouse(List<Player> listOfPlayers)
        {

            foreach (var player in listOfPlayers) //PlayHouse();
            {
                if (player.Name == "house")
                {
                    player.Score += 0; //ShowDarkCard();

                    while (player.Score < 17)
                    {
                        player.Score += Deck.GetCard(Deck.newDeck);
                    }
                }
            }
        }
        private static void CheckWinners(List<Player> list)
        {
            var house = list.Where(_ => _.Name.StartsWith("house"));
            var players = list.Where(_ => _.Name.StartsWith("Player"));

            foreach (var player in players)
            {

            }
        }
        private static bool PlayAgain()
        {
            Console.WriteLine("Do you want to play another round?\n\n[1] Yes \n[2]  No");
            Int32.TryParse(Console.ReadLine(), out int playAgain);
            if (playAgain == 1)
                return true;
            else
                return false;
        }
        private static void BlackJackWin(string playerName, int playerScore)
        {
            Console.WriteLine($"Conratulations {playerName}! You got Black Jack and won {playerScore} ");
        }
        private static int PlaceBet(int tableMin, int tableMax)
        {
            Console.WriteLine($"Make bet between {tableMin} and {tableMax}");
            
            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), tableMin, tableMax).;
        }
        //public static int[] Tables(int table)
        //{
        //    int[] minMax;
        //    switch (table)
        //    {
        //        case 1:

        //    }

        //    return minMax;
        //}

    }
}
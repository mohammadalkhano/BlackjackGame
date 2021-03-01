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
            //Output.ShowMenu();
            var activePlayers = Player.CreatePlayer(BlackJack.SeclectPlayers());
            //Output.TableMenu();
            var table = BlackJack.SelectTable();

            while (gameRunning == true)
            {
                PlaceBets(activePlayers, table[0], table[1]);
                FirstGive(activePlayers);
                PlayPlayers(activePlayers);
                PlayHouse(activePlayers);
                //if (activePlayers.Count > 1)//House is always playing
                //    PlayHouse(activePlayers);

                CheckWinners(activePlayers);

                gameRunning = PlayAgain();
            }

        }
        private static void PlaceBets(List<Player> listOfPlayers, int minBet, int maxBet)
        {
            foreach (var player in listOfPlayers)
            {
                if (player.Name != "house")
                {
                    player.Bet = 0;
                    player.Bet = PlaceBet(player.Name, minBet, maxBet);
                }
            }
        }
        private static void FirstGive(List<Player> listOfPlayers)
        {
            var rand = new Random();
            foreach (var player in listOfPlayers)
            {
                player.Score = 0;
                player.Stay = false;
                if (player.Name != "house")
                {
                    player.Score += rand.Next(1, 10); // Deck.GetCard(Deck.newDeck);
                    player.Score += rand.Next(1, 10); // Deck.GetCard(Deck.newDeck);

                    //player.Score = 21;

                    if (player.Score == 21)
                    {
                        BlackJackWin(player.Name, player.Bet);
                    }
                    Console.WriteLine($"{player.Name} has a total of {player.Score}");
                }
            }

            foreach (var player in listOfPlayers)
            {
                if (player.Name == "house")
                {
                    player.Score += rand.Next(1, 10); // Deck.GetCard(Deck.newDeck);
                    player.Score += rand.Next(1, 10); // Deck.GetCard(Deck.newDeck);
                    Console.WriteLine($"{player.Name} has a total of {player.Score}");
                }
            }
        }
        private static void PlayPlayers(List<Player> listOfPlayers)
        {
            var rand = new Random();

            foreach (var player in listOfPlayers) //PlayPlayers();
            {
                if (player.Name != "house")
                {
                    while (player.Stay == false)
                    {
                        if (player.Score < 21)
                        {
                            Console.WriteLine($"{player.Name}, you have {player.Score}. [1]Hit or [2]stay?");
                            Int32.TryParse(Console.ReadLine(), out int hitOrStay);
                            if (hitOrStay == 2)
                                player.Stay = true;
                            else
                                player.Score += rand.Next(1, 10); // Deck.GetCard(Deck.newDeck); ;
                        }
                        else
                            player.Stay = true;
                    }

                    if (player.Score > 21)
                        Console.WriteLine($"{player.Name} gets {player.Score} (busted)");
                    else
                        Console.WriteLine($"{player.Name} gets {player.Score}");
                }
            }
        }
        private static void PlayHouse(List<Player> listOfPlayers)
        {
            var rand = new Random();

            foreach (var player in listOfPlayers) //PlayHouse();
            {
                if (player.Name == "house")
                {
                    player.Score += rand.Next(1, 10); //ShowDarkCard();

                    while (player.Score < 17)
                    {
                        player.Score += rand.Next(1, 10); // Deck.GetCard(Deck.newDeck);
                    }
                    Console.WriteLine($"{player.Name} gets {player.Score}");
                    Console.ReadLine();
                }
            }
        }
        private static void CheckWinners(List<Player> list)
        {
            //var house = list.Where(_ => _.Name.StartsWith("house"));
            //var players = list.Where(_ => _.Name.StartsWith("Player"));
            var houseScore = 0;

            foreach (var player in list)
            {
                if (player.Name == "house")
                    if (player.Score > 21)
                        Console.WriteLine("House got busted");
                    else
                        houseScore = player.Score;
            }
            foreach (var player in list)
            {
                if (player.Name != "house")
                {
                    if (player.Score > 21)
                        Console.WriteLine($"{player.Name} got {player.Score} and got busted.");
                    else
                    {

                        if (player.Score == houseScore)
                            Console.WriteLine($"{player.Name} got {player.Score} and are equal to the house.");
                        else if (player.Score > houseScore)
                            Console.WriteLine($"{player.Name} got {player.Score} and beat the house. You won ${player.Bet * 2}.");
                        else
                            Console.WriteLine($"{player.Name} got {player.Score} and lost to the house.");
                    }
                }
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
        private static void BlackJackWin(string playerName, int playerBet)
        {
            Console.WriteLine($"Conratulations {playerName}! You got Black Jack and won {playerBet + (playerBet * 1.5)} ");
        }

        private static int PlaceBet(string playerName, int tableMin, int tableMax)
        {
            Console.WriteLine($"{playerName} place bet between {tableMin} and {tableMax}");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), tableMin, tableMax);
        }
    }
}
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
            
            var activePlayers = Player.CreatePlayer(BlackJack.SeclectPlayers());
            var table = BlackJack.SelectTable();

            while (gameRunning == true)

                {
                PlaceBets(activePlayers,table[0],table[1]);
                FirstGive(activePlayers);
                PlayPlayers(activePlayers);
                PlayHouse(activePlayers);

                CheckWinners(activePlayers);

                gameRunning = PlayAgain();
                }
            }
        /// <summary>
        /// Asks user to place their bet between min and max
        /// </summary>
        /// <param name="players">List of active players</param>
        /// <param name="minBet">Min amount of bet according to table rules</param>
        /// <param name="maxBet">Max amount of bet according to table rules</param>
        private static void PlaceBets(List<Player> players,int minBet,int maxBet)
            {
            foreach (var player in players)
                {
                if (player.Name != "house")
                    {
                    player.Bet = 0;
                    player.Bet = PlaceBet(player.Name,minBet,maxBet);
                    }
                }
            }
        /// <summary>
        /// Hands two cards to each players, not "house"
        /// </summary>
        /// <param name="players">List of active players</param>
        private static void FirstGive(List<Player> players)
            {
            var rand = new Random();
            foreach (var player in players)
                {
                player.Score = 0;
                player.Stay = false;
                if (player.Name != "house")
                    {
                    player.Score += rand.Next(1,10); // Deck.GetCard(Deck.newDeck);
                    player.Score += rand.Next(1,10); // Deck.GetCard(Deck.newDeck);

                    //player.Score = 21;

                    if (player.Score == 21)
                        {
                        BlackJackWin(player.Name,player.Bet);
                        }
                    Console.WriteLine($"{player.Name} has a total of {player.Score}");
                    }
                }

            foreach (var player in players)
                {
                if (player.Name == "house")
                    {
                    player.Score += rand.Next(1,10); // Deck.GetCard(Deck.newDeck);
                    player.Score += rand.Next(1,10); // Deck.GetCard(Deck.newDeck);
                    Console.WriteLine($"{player.Name} has a total of {player.Score}");

                    }
                }
            }
        /// <summary>
        /// Plays each players turn, asking "Hit" or "Stay" until they stop or exceed 21
        /// </summary>
        /// <param name="players">List of active players</param>
        private static void PlayPlayers(List<Player> players)
            {
            var rand = new Random();

            foreach (var player in players) //PlayPlayers();
                {
                if (player.Name != "house")
                    {
                    while (player.Stay == false)
                        {
                        if (player.Score < 21)
                            {
                            Console.WriteLine($"{player.Name}, you have {player.Score}. [1]Hit or [2]stay?");
                            Int32.TryParse(Console.ReadLine(),out int hitOrStay);
                            if (hitOrStay == 2)
                                player.Stay = true;
                            else
                                player.Score += rand.Next(1,10); // Deck.GetCard(Deck.newDeck); ;
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
        /// <summary>
        /// Plays "house" automatic until score exceeds 16
        /// </summary>
        /// <param name="players">List of active players</param>
        private static void PlayHouse(List<Player> players)
            {
            var rand = new Random();

            foreach (var player in players) //PlayHouse();
                {
                if (player.Name == "house")
                    {
                    player.Score += rand.Next(1,10); //ShowDarkCard();

                    while (player.Score < 17)
                        {
                        player.Score += rand.Next(1,10); // Deck.GetCard(Deck.newDeck);
                        }
                    Console.WriteLine($"{player.Name} gets {player.Score}");
                    Console.ReadLine();
                    }
                }
            }
        /// <summary>
        /// Matches players scor with house to check winners
        /// </summary>
        /// <param name="list">List of active players</param>
        private static void CheckWinners(List<Player> list)
            {
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
                        Output.LogoMeddelande($"{player.Name} got {player.Score} and got busted.");
                    else
                        {

                        if (player.Score == houseScore)
                            Console.WriteLine($"{player.Name} got {player.Score} and are equal to the house.");
                        else if (player.Score > houseScore)
                            Output.LogoMeddelande($"{player.Name} got {player.Score} and beat the house. You won ${player.Bet * 2}.");
                        else
                            Console.Clear();
                        Output.LogoMeddelande($"{player.Name} got {player.Score} and lost to the house.");
                        }
                    }
                }

            }
        /// <summary>
        /// Asks user to play again
        /// </summary>
        /// <returns>Bool value</returns>
        private static bool PlayAgain()
            {
            Console.WriteLine("Do you want to play another round?\n\n[1] Yes \n[2]  No");
            Int32.TryParse(Console.ReadLine(),out int playAgain);
            if (playAgain == 1)
                return true;
            else
                return false;
            }
        /// <summary>
        /// Prints message if user gets 21 first round
        /// </summary>
        /// <param name="playerName">Name of player</param>
        /// <param name="playerBet">Players bet</param>
        private static void BlackJackWin(string playerName,int playerBet)
            {
            Output.LogoMeddelande($"Conratulations {playerName}! You got Black Jack and won {playerBet + (playerBet * 1.5)} ");
            }

        private static int PlaceBet(string playerName,int tableMin,int tableMax)
            {
            Console.WriteLine($"{playerName} place bet between {tableMin} and {tableMax}");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(),tableMin,tableMax);
            }
        }
    }
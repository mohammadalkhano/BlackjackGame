namespace BlackJackGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public static List<Models.Card> GameDeck { get; set; }

        public static void RunGame()
        {
            var gameRunning = true;
            Output.Logo();
            Console.ReadKey();

            while (gameRunning == true)
            {
                GameDeck = Deck.CreateMultipleDecks(Deck.GetDeck(), 4);
                Console.Clear();
                Output.ShowMenu();

                var table = BlackJack.SelectTable();

                Deck.GetCard(GameDeck);

                Console.Clear();

                Output.LogoMeddelande("How many players? (1-7)");
                var activePlayers = Player.CreatePlayer(PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 7));

                Console.Clear();

                PlaceBets(activePlayers, table[0], table[1]);

                Console.Clear();

                FirstGive(activePlayers);

                Console.ReadLine();

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
        private static void PlaceBets(List<Player> players, int minBet, int maxBet)
        {
            foreach (var player in players)
            {

                Output.PlayerInfoOutput(players);
                if (player.Name != "House")
                {
                    player.Bet = 0;
                    player.Bet = PlaceBet(player.Name, minBet, maxBet);
                }
                Console.Clear();

            }
        }
        /// <summary>
        /// Hands two cards to each players, not "House"
        /// </summary>
        /// <param name="players">List of active players</param>
        private static void FirstGive(List<Player> players)
        {
            var rand = new Random();

            foreach (var player in players)
            {
                player.Score = 0;
                player.Stay = false;
                if (player.Name != "House")
                {

                    while (player.Cards.Count < 2)
                    {
                        var printX = 16 + players.Count;
                        var printY = 2;

                        Output.PlayerInfoOutput(players);
                        var newCard = Deck.GetCard(GameDeck);
                        player.Cards.Add(newCard);
                        player.Score += newCard.CardNumber;
                        Output.LogoMeddelande($"{player.Name}, your total is {player.Score}");
                        for (int i = 0; i < player.Cards.Count; i++)
                        {
                            Output.PrintCard(printX, printY, player.Cards[i].CardNumber, player.Cards[i].CardSymbol);
                            printX += 1;
                            printY += 6;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        GameDeck.Remove(newCard);
                    }
                    if (player.Score == 21)
                    {
                        BlackJackWin(player.Name, player.Bet);
                    }
                }
            }
            foreach (var player in players)
            {
                if (player.Name == "House")
                {

                    while (player.Cards.Count < 2)
                    {
                        var printX = 1 + players.Count;
                        var printY = 90;

                        Output.PlayerInfoOutput(players);
                        var newCard = Deck.GetCard(GameDeck);
                        player.Cards.Add(newCard);
                        player.Score += newCard.CardNumber;
                        Output.LogoMeddelande($"{player.Name} total is {player.Score}");
                        //foreach (var card in player.Cards)
                        for (int i = 0; i < player.Cards.Count; i++)
                        {
                            Output.PrintCard(printX, printY, player.Cards[i].CardNumber, player.Cards[i].CardSymbol);
                            printX += 1;
                            printY += 6;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        GameDeck.Remove(newCard);
                    }
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

            foreach (var player in players) 
            {
                if (player.Name != "House")
                {
                    while (player.Stay == false)
                    {
                        if (player.Score < 21)
                        {
                            var printX = 17 + players.Count;
                            var printY = 2;

                            Output.PlayerInfoOutput(players);
                            Output.LogoMeddelandeDouble($"{player.Name}, your total is {player.Score}.", "[1]Hit or [2]stay?");

                            for (int i = 0; i < player.Cards.Count; i++)
                            {
                                Output.PrintCard(printX, printY, player.Cards[i].CardNumber, player.Cards[i].CardSymbol);
                                printX += 1;
                                printY += 6;
                            }

                            var hitOrStay = PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 2);
                            if (hitOrStay == 2)
                                player.Stay = true;
                            else
                            {
                                var newCard = Deck.GetCard(GameDeck);
                                player.Cards.Add(newCard);
                                player.Score += newCard.CardNumber;
                                GameDeck.Remove(newCard);
                                Console.Clear();
                            }
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
        /// Plays "House" automatic until score exceeds 16
        /// </summary>
        /// <param name="players">List of active players</param>
        private static void PlayHouse(List<Player> players)
        {
            var rand = new Random();

            foreach (var player in players) //PlayHouse();
            {
                if (player.Name == "House")
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
        /// <summary>
        /// Matches players scor with House to check winners
        /// </summary>
        /// <param name="list">List of active players</param>
        private static void CheckWinners(List<Player> list)
        {
            var houseScore = 0;

            foreach (var player in list)
            {
                if (player.Name == "House")
                    if (player.Score > 21)
                        Console.WriteLine("House got busted");
                    else
                        houseScore = player.Score;
            }
            foreach (var player in list)
            {
                if (player.Name != "House")
                {
                    if (player.Score > 21)
                        Console.WriteLine($"{player.Name} got {player.Score} and got busted.");
                    else
                    {

                        if (player.Score == houseScore)
                            Console.WriteLine($"{player.Name} got {player.Score} and are equal to the House.");
                        else if (player.Score > houseScore)
                            Console.WriteLine($"{player.Name} got {player.Score} and beat the House. You won ${player.Bet * 2}.");
                        else
                            Console.WriteLine($"{player.Name} got {player.Score} and lost to the House.");
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
            Int32.TryParse(Console.ReadLine(), out int playAgain);
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
        private static void BlackJackWin(string playerName, int playerBet)
        {
            Output.LogoMeddelandeDouble($"Conratulations {playerName}!", $"You got Black Jack and won {playerBet + (playerBet * 1.5)} ");
            Console.ReadKey();
            Console.Clear();
        }

        private static int PlaceBet(string playerName, int tableMin, int tableMax)
        {
            //Console.WriteLine($"{playerName} place bet between {tableMin} and {tableMax}");

            Output.LogoMeddelande($"{playerName} place bet between {tableMin} and {tableMax}");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), tableMin, tableMax);
        }
    }
}
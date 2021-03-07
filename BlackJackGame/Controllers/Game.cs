namespace BlackJackGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game // Philip
    {
        //Basic game loop
        public static bool GameRunning { get; set; } = true;
        //Deck for playing Black Jack
        public static List<Models.Card> GameDeck { get; set; }
        //Sets minBet and maxBet depending on what table user chooses
        public static List<int> Table { get; set; }
        //List of active players + house/dealer
        public static List<Player> ActivePlayers { get; set; }
        //Variable for each new card pulled from the deck
        public static Models.Card NewCard { get; set; }
        //Default ProTip (if user gets 21)
        public static string ProTip { get; set; } = "You got Black Jack, baby. Just sit tight.";

        //Sets starting point for printing cards on screen
        public static int PlayerPrintX { get; set; } = 17;
        public static int PlayerPrintY { get; set; } = 2;
        public static int HousePrintX { get; set; } = 1;
        public static int HousePrintY { get; set; } = 90;

        /// <summary>
        /// Contains the game loop
        /// Philip
        /// </summary>        
        public static void RunGame()
        {
            //Prints game logo
            Output.Logo();
            Console.ReadKey();

            //Game loop starts
            while (GameRunning == true)
            {
                //Creates a random list containing 4 full decks (52*4 cards)
                GameDeck = Deck.CreateMultipleDecks(Deck.GetDeck(), 4);
                Console.Clear();
                //Prints table menu
                Output.ShowMenu();

                //Sets minBet/maxBet based on user choise of table
                Table = BlackJack.SelectTable();
                Console.Clear();

                Output.LogoMeddelande("How many players? (1-7)");
                //Sets numbers of players according to user input
                ActivePlayers = Player.CreatePlayer(PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 7));

                Console.Clear();

                PlaceBets(ActivePlayers, Table[0], Table[1]);

                FirstGive(ActivePlayers);
                Console.Clear();
                PlayPlayers(ActivePlayers);
                Console.Clear();
                PlayHouse(ActivePlayers);
                Console.Clear();

                CheckWinners(ActivePlayers);

                GameRunning = PlayAgain();
            }
        }
        /// <summary>
        /// Asks all players to place their bet between min and max
        /// Philip
        /// </summary>
        /// <param name="players">List of active players</param>
        /// <param name="minBet">Min amount of bet according to table rules</param>
        /// <param name="maxBet">Max amount of bet according to table rules</param>
        private static void PlaceBets(List<Player> players, int minBet, int maxBet)
        {
            foreach (var player in players)
            {
                Output.PlayerInfoOutput(players);
                //Only asks players to place their bets, not House
                if (player.Name != "House")
                {
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
            foreach (var player in players)
            {
                //Sets printing points for cards 
                var printX = PlayerPrintX + players.Count;
                var printY = PlayerPrintY;

                if (player.Name != "House")
                {
                    //Runs loop until player has two cards
                    while (player.Cards.Count < 2)
                    {

                        Output.PlayerInfoOutput(players);
                        //Returns a random card from list
                        NewCard = Deck.GetCard(GameDeck);
                        //Adds card to players hand
                        player.Cards.Add(NewCard);
                        //Adds score to players total
                        player.Score += NewCard.CardNumber;
                        Output.LogoMeddelandeDouble($"{player.Name}, your total is {player.Score}", "Press any key to continiue...");

                        //Prints players cards to console
                        PrintPlayersCards(player, printX, printY);

                        Console.ReadLine();
                        Console.Clear();
                        //Removes card from deck
                        GameDeck.Remove(NewCard);
                    }
                    if (player.Score == 21)
                    {
                        //If player gets 21 in first give, its automatic Black Jack (wins x 2.5)
                        BlackJackWin(player.Name, player.Bet);
                    }
                }
            }
            foreach (var player in players)
            {
                //Sets starting position for dealers cards
                var printX = HousePrintX + players.Count;
                var printY = HousePrintY;

                //Plays house/dealer
                if (player.Name == "House")
                {
                    while (player.Cards.Count < 1)
                    {
                        Output.PlayerInfoOutput(players);
                        //Returns a random card from list
                        NewCard = Deck.GetCard(GameDeck);
                        //Adds card to dealers hand
                        player.Cards.Add(NewCard);
                        //Adds score to dealers total
                        player.Score += NewCard.CardNumber;
                        Output.LogoMeddelandeDouble($"{player.Name} total is {player.Score}", "Press any key to continiue...");

                        //Prints dealers card to console
                        PrintPlayersCards(player, printX, printY);
                        Console.ReadLine();
                        //Prints one card upside down
                        PrintDarkCard(player, printX, printY);
                        Console.ReadLine();
                        Console.Clear();
                        //Removes card from deck
                        GameDeck.Remove(NewCard);
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
            foreach (var player in players)
            {
                var printX = PlayerPrintX + players.Count;
                var printY = PlayerPrintY;
                var proTip = ProTip;

                if (player.Name != "House")
                {
                    
                    while (player.Stay == false)
                    {
                        if (player.Score < 21)
                        {
                            proTip = SetProTip(player);

                            Output.PlayerInfoOutput(players);

                            Output.LogoMeddelandeTripple($"{player.Name}, your total is {player.Score}.", "[1]Hit or [2]stay?", $"ProTp: {proTip}");

                            PrintPlayersCards(player, printX, printY);

                            var hitOrStay = PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 2);
                            if (hitOrStay == 2)
                            {
                                player.Stay = true;
                                Console.Clear();
                            }
                            else
                            {
                                var NewCard = Deck.GetCard(GameDeck);
                                player.Cards.Add(NewCard);
                                player.Score += NewCard.CardNumber;
                                GameDeck.Remove(NewCard);
                                Console.Clear();
                            }
                        }
                        else
                        {
                            player.Stay = true;

                            Output.PlayerInfoOutput(players);
                            Output.LogoMeddelandeDouble($"{player.Name}, your total is {player.Score}.", "Press any key to continiue...");
                            PrintPlayersCards(player, printX, printY);
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                }
            }
        }
        /// <summary>
        /// Decides what ProTip to give depending on players total score
        /// </summary>
        /// <param name="player">Active player</param>
        /// <returns>String value</returns>
        private static string SetProTip(Player player)
        {
            string proTip;
            if (player.Score < 10)
                proTip = "You should really take one more card!";
            else if (player.Score < 14)
                proTip = "I think you should take one more card";
            else if (player.Score < 17)
                proTip = "Maybe ONE more card..?";
            else if (player.Score < 19)
                proTip = "I'm thinking; stay!";
            else
                proTip = "For the love of God, STAY!";
            return proTip;
        }

        /// <summary>
        /// Displays players cards
        /// </summary>
        /// <param name="player">Active player</param>
        /// <param name="printX">Where on the x-axis the card will be printed</param>
        /// <param name="printY">Where on the y-axis the card will be printed</param>
        private static void PrintPlayersCards(Player player, int printX, int printY)
        {
            for (int i = 0; i < player.Cards.Count; i++)
            {
                Output.PrintCard(printX, printY, player.Cards[i].CardNumber, player.Cards[i].CardSymbol);
                printX += 1;
                printY += 6;
            }
        }
        /// <summary>
        /// Displays one card with no value ("dark" or upside down)
        /// </summary>
        /// <param name="player">Active player(House)</param>
        /// <param name="printX">Where on the x-axis the card will be printed</param>
        /// <param name="printY">Where on the y-axis the card will be printed</param>
        private static void PrintDarkCard(Player player, int printX, int printY)
        {
            for (int i = 0; i < player.Cards.Count; i++)
            {
                printX += 1;
                printY += 6;
                Output.DarkCard(printX, printY);
            }
        }
        /// <summary>
        /// Plays "House" automatic until score exceeds 16
        /// </summary>
        /// <param name="players">List of active players</param>
        private static void PlayHouse(List<Player> players)
        {
            foreach (var player in players)
            {
                var printX = HousePrintX + players.Count;
                var printY = HousePrintY;
                if (player.Name == "House")
                {
                    while (player.Score < 17)
                    {
                        Output.PlayerInfoOutput(players);
                        Output.LogoMeddelande($"{player.Name} total is {player.Score}.");

                        PrintPlayersCards(player, printX, printY);

                        var NewCard = Deck.GetCard(GameDeck);
                        player.Cards.Add(NewCard);
                        player.Score += NewCard.CardNumber;
                        GameDeck.Remove(NewCard);
                        Console.ReadKey();
                        Console.Clear();
                    }

                    Output.PlayerInfoOutput(players);
                    Output.LogoMeddelandeDouble($"{player.Name} total is {player.Score}.", "Press any key to continiue");

                    PrintPlayersCards(player, printX, printY);

                    Console.ReadKey();
                    Console.Clear();
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
                        Console.WriteLine($"{player.Name} got {player.Score} and lost ${player.Bet}.");
                    else
                    {

                        if (player.Score == houseScore)
                            Console.WriteLine($"{player.Name} got {player.Score} and are equal to the House and won back ${player.Bet}.");
                        else if (player.Score > houseScore)
                            Console.WriteLine($"{player.Name} got {player.Score} and beat the House. You won ${player.Bet * 2}.");
                        else
                            Console.WriteLine($"{player.Name} got {player.Score} and lost ${player.Bet}.");
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
        /// <summary>
        /// Places the bet.
        /// </summary>
        /// <param name="playerName">Name of the player.</param>
        /// <param name="tableMin">The table minimum.</param>
        /// <param name="tableMax">The table maximum.</param>
        /// <returns></returns>
        private static int PlaceBet(string playerName, int tableMin, int tableMax)
        {

            Output.LogoMeddelande($"{playerName} place bet between {tableMin} and {tableMax}");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), tableMin, tableMax);
        }
    }
}
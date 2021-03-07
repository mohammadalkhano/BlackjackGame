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
        public static string ProTip { get; set; }

        //Sets starting point for printing cards on screen
        public static int PlayerPrintX { get; set; } = 16;
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
                Table = SelectTable();
                Console.Clear();

                Output.LogoMeddelande("How many players? (1-7)");
                //Sets numbers of players according to user input
                ActivePlayers = Player.CreatePlayer(PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 7));

                Console.Clear();
                //Each player make their bets
                PlaceBets(ActivePlayers, Table[0], Table[1]);
                //Each player gets to cards, dealer/house gets one
                FirstGive(ActivePlayers);
                Console.Clear();
                //Each players play their turn
                PlayPlayers(ActivePlayers);
                Console.Clear();
                //Dealer play it's turn
                PlayHouse(ActivePlayers);
                Console.Clear();
                //Automatic check for winners
                CheckWinners(ActivePlayers);
                //Asks if user wants to play again
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
                        //Prints score board
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
                        Console.ReadKey();
                        Console.Clear();
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
                        //Prints score board
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
                if (player.Name != "House")
                {
                    while (player.Stay == false)
                    {
                        if (player.Score < 21)
                        {
                            //Sets ProTip based on total score
                            var proTip = SetProTip(player);
                            //Prints score board
                            Output.PlayerInfoOutput(players);

                            Output.LogoMeddelandeTripple($"{player.Name}, your total is {player.Score}.", "[1]Hit or [2]stay?", $"ProTp: {proTip}");

                            PrintPlayersCards(player, printX, printY);

                            //Player gets to choose between 1 or 2
                            if (PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 2) == 2)
                            {
                                player.Stay = true;
                                Console.Clear();
                            }
                            else
                            {
                                //If player wants one more card
                                //Returns a random card from list
                                NewCard = Deck.GetCard(GameDeck);
                                //Adds card to players hand
                                player.Cards.Add(NewCard);
                                //Adds score to players total
                                player.Score += NewCard.CardNumber;
                                //Check if player has Ace on hand
                                CheckAceValue(player);
                                //Removes card from deck
                                GameDeck.Remove(NewCard);
                                Console.Clear();

                            }
                        }
                        else
                        {
                            //Player total score is 21 or more
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
        /// Check if user has Ace on hand and changes its value to 1 if total score is >21
        /// </summary>
        /// <param name="player">Active player</param>
        private static void CheckAceValue(Player player)
        {
            if (player.Score > 21)
            {
                player.Score = 0;
                foreach (var item in player.Cards)
                {
                    if (item.CardSymbolB == "A")
                    {
                        item.CardNumber = 1;
                    }
                    player.Score += item.CardNumber;
                }
            }
        }

        /// <summary>
        /// Plays "House" automatic until score exceeds 16
        /// Philip
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

                        NewCard = Deck.GetCard(GameDeck);
                        player.Cards.Add(NewCard);
                        player.Score += NewCard.CardNumber;
                        //Check if player has Ace on hand
                        CheckAceValue(player);
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
        /// Decides what ProTip to give depending on players total score
        /// Philip
        /// </summary>
        /// <param name="player">Active player</param>
        public static string SetProTip(Player player)
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
        /// Philip
        /// </summary>
        /// <param name="player">Active player</param>
        /// <param name="printX">Where on the x-axis the card will be printed</param>
        /// <param name="printY">Where on the y-axis the card will be printed</param>
        private static void PrintPlayersCards(Player player, int printX, int printY)
        {
            for (int i = 0; i < player.Cards.Count; i++)
            {
                if (player.Cards[i].CardSymbolB == null)
                    Output.PrintCard(printX, printY, player.Cards[i].CardNumber.ToString(), player.Cards[i].CardSymbol);
                else
                    Output.PrintCard(printX, printY, player.Cards[i].CardSymbolB.ToString(), player.Cards[i].CardSymbol);
                printX += 1;
                printY += 6;
            }
        }
        /// <summary>
        /// Displays one card with no value ("dark" or upside down)
        /// Philip
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
        /// Matches players score with House to check winners
        /// Philip
        /// </summary>
        /// <param name="list">List of active players</param>
        private static void CheckWinners(List<Player> list)
        {
            var houseScore = 0;
            //First check House score
            foreach (var player in list)
            {
                if (player.Name == "House")
                    if (player.Score > 21)
                        Console.WriteLine("House got busted");
                    else
                        houseScore = player.Score;
            }
            //Matches players score with house to check for winners
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
        /// Philip
        /// </summary>
        /// <returns>Bool value</returns>
        private static bool PlayAgain()
        {
            Console.WriteLine("Do you want to play another round?\n\n[1] Yes \n[2]  No");
            //If user input is 1, a new games starts. Otherwise program quits
            if (PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), 1, 2) == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Prints message if user gets 21 first round
        /// Philip
        /// </summary>
        /// <param name="playerName">Name of player</param>
        /// <param name="playerBet">Players bet</param>
        private static void BlackJackWin(string playerName, int playerBet)
        {
            Output.LogoMeddelandeDouble($"Conratulations {playerName}!", $"You got Black Jack and won {playerBet + (playerBet * 1.5)} ");
        }
        /// <summary>
        /// Places the bet
        /// Philip
        /// </summary>
        /// <param name="playerName">Name of the player.</param>
        /// <param name="tableMin">The table minimum.</param>
        /// <param name="tableMax">The table maximum.</param>
        /// <returns>Int value</returns>
        private static int PlaceBet(string playerName, int tableMin, int tableMax)
        {

            Output.LogoMeddelande($"{playerName} place bet between {tableMin} and {tableMax}");

            return PlayerInput.CheckMinMaxInput(PlayerInput.InvalidInputCheck(), tableMin, tableMax);
        }
        /// <summary>
        /// Asks user to select a table. Each tables has own rules for min and max bet
        /// Philip
        /// </summary>
        /// <returns>List containing min and max value</returns>
        public static List<int> SelectTable()
        {
            Console.WriteLine();
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
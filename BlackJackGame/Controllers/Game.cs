namespace BlackJackGame
{
    using System;
    public static class Game
    {
        public static void RunGame()
        {
            var gameRunning = true;
            Output.ShowMenu();
            Player.CreatePlayer(BlackJack.SeclectPlayers());
            BlackJack.SelectTable();
            BlackJack.ResetDeck();

            while (gameRunning == true)
            {
                foreach (player in Players)  // FirstGive();
                {
                    if (player.name != "house")
                    {
                        player.bet = PlaceBet();
                        player.score += BlackJack.GiveCard("open");
                        player.score += BlackJack.GiveCard("open");

                        if (player.score == 21)
                        {
                            BlackJack(player.name);
                        }
                    }
                }

                foreach (player in Players)
                {
                    if (player.name == "house")
                    {
                        player.score = BlackJack.GiveCard("open");
                        player.score = BlackJack.GiveCard("close");
                    }
                }

                foreach (player in Players) //PlayPlayers();
                {
                    if (player.name != "house")
                    {
                        while (player.score < 21 || player.stay == false)
                        {
                            Console.WriteLine("[1]Hit or [2]stay?");
                            Int32.TryParse(Console.ReadLine(), out int hitorStay);
                            if (hitOrStay == 2)
                                player.stay = true;
                            else
                                player.score = BlackJack.GiveCard("open");
                        }
                    }
                }

                if (activePlayers > 0)
                {
                    foreach (player in Players) //PlayHouse();
                    {
                        if (player.name == "house")
                        {
                            player.score += ShowDarkCard();

                            while (player.score < 17)
                            {
                                player.score += BlackJack.GiveCard("open");
                            }
                        }
                    }
                }

                CheckWinner();

                gameRunning = PlayAgain();
            }

        }

    }
}
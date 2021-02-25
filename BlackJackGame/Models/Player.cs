using System.Collections.Generic;
using System;

namespace BlackJackGame
{
    public class Player
    {
        public int Bet { get; set; } = 0;
        public List<string> Cards { get; set; }
        public string Name { get; set; }
        public int Score { get; set; } = 0;
        public bool Stay { get; set; } = false;

        public Player(int playerNumber)
        {
            Name = "Player " + playerNumber;
        }

        public static void CreatePlayer(int numberOfPlayers)
        {

            var playersList = new List<Player>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                playersList.Add(new Player(i + 1));
            }
        }

    }
}
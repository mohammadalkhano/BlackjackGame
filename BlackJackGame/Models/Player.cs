using System.Collections.Generic;
using System;

namespace BlackJackGame
{
    public class Player
    {
        public int Bet { get; set; }
        public List<string> Cards { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool Stay { get; set; }

        public Player(int playerNumber)
        {
            Bet = 0;
            Cards = new List<string>();
            Name = "Player " + playerNumber;
            Score = 0;
            Stay = false;
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
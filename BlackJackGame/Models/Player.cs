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

        public Player(string playerName)
        {
            Bet = 0;
            Cards = new List<string>();
            Name = playerName;
            Score = 0;
            Stay = false;
        }

        public static List<Player> CreatePlayer(int numberOfPlayers)
        {

            var playersList = new List<Player>();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                playersList.Add(new Player("Player " + (i+1)));
            }

            playersList.Add(new Player("house")); //Adds player House

            return playersList;
        }

    }
}
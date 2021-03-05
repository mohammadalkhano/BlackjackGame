using System.Collections.Generic;
using System;
using BlackJackGame.Models;

namespace BlackJackGame
{
    public class Player
    {
        public int Bet { get; set; }
        public List<Card> Cards { get; set; }
        public List<string> HouseDarkCard { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool Stay { get; set; }

        public Player(string playerName)
        {
            Bet = 0;
            Cards = new List<Card>();
            Name = playerName;
            Score = 0;
            Stay = false;
            HouseDarkCard = new List<string>(); //Second card to house is not visible
        }
        /// <summary>
        /// Creates the amount of players selected by user. Automatic creates a player named "house"
        /// </summary>
        /// <param name="numberOfPlayers">Number of players selected by user</param>
        /// <returns>List of active players</returns>
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
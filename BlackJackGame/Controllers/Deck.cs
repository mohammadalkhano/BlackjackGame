﻿using BlackJackGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackGame
{
    public class Deck
    {
        //Card GetCards = new Card();

        public string[] cards { get; set; } = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Q", "J", "K" };
        public string[] cardType { get; set; } = new string[4] { "♥", "♣", "♠", "♦" };

        /*----Tänkte att skapa list of Card klassen för att underlätta åtgången på Card Number----*/
        /*public List<Card> MyCards { get; set; } = new List<Card>
        {new Card { Number ="2", Type= "H" } };*/

        /// <summary>
        /// Generates the deck(52 Cards).
        /// </summary>
        /// <returns></returns>
        public List<string> GenerateDeck()
        {
            List<string> listOfCards = new List<string>();
            for (int i = 0; i < cardType.Length; i++)
            {
                for (int j = 0; j < cards.Length; j++)
                {
                    listOfCards.Add(cards[j] + cardType[i]);
                }
            }
            return listOfCards;
        }

        /// <summary>
        /// Builds the deck for game.
        /// </summary>
        /// <param name="deck">The deck.</param>
        /// <returns></returns>
        public List<string> BuildDeckForGame(List<string> deck)
        {
            List<string> randomCards = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                var random = new Random();
                var randomList = deck.OrderBy(i => random.Next(104, 156));
                foreach (var item in randomList)
                {
                    randomCards.Add(item);
                }
            }
            return randomCards;
        }

        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <param name="deck">The deck.</param>
        /// <returns></returns>
        public string GetCard(List<string> deck)
        
        {
            var random = new Random();
            var randomList = deck.OrderBy(i => random.Next(104, 156));

            var card = deck[deck.Count - 1];
            deck.RemoveAt(card.IndexOf(card));

            //var card1 = deck.FirstOrDefault();
            //deck.Remove(card1);

            return card;
        }

        public void ResetCards()
        {
            throw new System.NotImplementedException();
        }
    }
}
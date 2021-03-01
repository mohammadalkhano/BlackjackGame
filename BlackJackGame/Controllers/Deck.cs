using BlackJackGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackGame
{
    public static class Deck
    {
        //Card GetCards = new Card();

        public static string[] cards { get; set; } = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Q", "J", "K" };
        public static string[] cardType { get; set; } = new string[4] { "♥", "♣", "♠", "♦" };


        public static List<string> newDeck = BuildDeckForGame(GenerateDeck());


        /*----Tänkte att skapa list of Card klassen för att underlätta åtgången på Card Number----*/
        /*public List<Card> MyCards { get; set; } = new List<Card>
        {new Card { Number ="2", Type= "H" } };*/

        /// <summary>
        /// Generates the deck(52 Cards).
        /// </summary>
        /// <returns></returns>
        public static List<string> GenerateDeck()
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
        public static List<string> BuildDeckForGame(List<string> deck)
        {
            List<string> gameDeck = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                foreach (var item in deck)
                {
                    gameDeck.Add(item);
                }
            }


            return gameDeck;
        }

        
        
        /// <summary>
        /// Suffles the list.
        /// </summary>
        /// <param name="deck">The deck.</param>
        /// <returns></returns>
        public static List<string> SuffleList(List<string> deck)

        {
            List<string> randomCards = new List<string>();


            //var random = new Random();
            //var randomList = Cards.OrderBy(i => random.Next(0, 208));

            var random = new Random();
            var randomList = deck.OrderBy(i => random.Next(0,208));
            foreach (var item in randomList)
            {
                randomCards.Add(item);
            }


            return randomCards;
        }


        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <param name="deck">The deck.</param>
        /// <returns></returns>
        public static int GetCard(List<string> cards)
        {

            //var card = Cards.FirstOrDefault();
            //Cards.Remove(card);

            int score = 0;
            var card = cards[cards.Count - 1];



            cards.Remove(card);

            return score;
        }

        /// <summary>
        /// Resets the cards .
        /// </summary>
        public static void ResetCards()
        {

            //throw new System.NotImplementedException();

            Deck.SuffleList(BuildDeckForGame(GenerateDeck()));

        }
    }
}
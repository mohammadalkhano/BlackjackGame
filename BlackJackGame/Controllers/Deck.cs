using BlackJackGame.Models;
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
                var randomList = deck.OrderBy(i => random.Next());
                foreach (var item in randomList)
                {
                    /*----Used to get the symbol printed when you print the list---*/
                    //Console.OutputEncoding = Encoding.UTF8;
                    randomCards.Add(item);
                    
                }
            }
            return randomCards;
        }
        public void GetCard()
        {
            throw new System.NotImplementedException();
        }

        public void ResetCards()
        {
            throw new System.NotImplementedException();
        }
    }
}
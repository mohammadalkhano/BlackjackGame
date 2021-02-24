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
        /// <summary>
        /// Generates the card.
        /// </summary>
        /// <returns></returns>
        public List<string> GenerateCard()
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
        /// Gets the card.
        /// </summary>
        /// <param name="Cards">The cards.</param>
        /// <returns></returns>
        public List<string> GetCard(List<string>Cards)
        {
            List<string> randomCards = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                var random = new Random();                
                var randomList = Cards.OrderBy(i => random.Next());
                foreach (var item in randomList)
                {
                    
                    Console.OutputEncoding = Encoding.UTF8;
                    randomCards.Add(item);
                    Console.WriteLine(item);
                }
            }
            return randomCards;
        }


        public void ResetCards()
        {
            throw new System.NotImplementedException();
        }
    }
}
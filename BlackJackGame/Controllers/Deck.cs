using BlackJackGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJackGame
{
    public static class Deck
    {

        private static int[] Cards { get; set; } = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        private static string[] CardType { get; set; } = new string[4] { "♥", "♣", "♠", "♦" };
        public static List<Card> CardsForGame { get; set; } = Deck.CreateMultipleDecks(Deck.GetDeck(), 4);

        /// <summary>
        /// Generates the deck(52 Cards).
        /// </summary>
        /// <returns></returns>
        public static List<Card> GetDeck()
        {
            List<Card> gameDeck = new List<Card>();

            for (int i = 0; i < CardType.Length; i++)
            {
                for (int j = 0; j < Cards.Length; j++)
                {
                    var card = new Card(Cards[j], CardType[i]);
                    if (Cards[j] == 1)
                    {
                        card.CardSymbolB = "A";
                    }
                    else if (Cards[j] == 11)
                    {
                        card.CardSymbolB = "J";
                    }
                    else if (Cards[j] == 12)
                    {
                        card.CardSymbolB = "Q";
                    }
                    else if (Cards[j] == 13)
                    {
                        card.CardSymbolB = "K";
                    }
                    gameDeck.Add(card);

                }
            }

            return gameDeck;
        }
        /// <summary>
        /// Creates the multiple decks and return random list of the cards.
        /// </summary>
        /// <param name="deck">The deck.</param>
        /// <param name="numberOfDecks">The number of decks.</param>
        /// <returns></returns>
        public static List<Card> CreateMultipleDecks(List<Card> deck, int numberOfDecks)
        {
            var newDeck = new List<Card>();
            var rnd = new Random();

            for (int j = 0; j < numberOfDecks; j++)
            {
                foreach (var card in deck)
                {
                    newDeck.Add(card);
                }
            }

            var shuffledDeck = newDeck.Select(item => new { item, order = rnd.Next() })
                .OrderBy(x => x.order)
                .Select(x => x.item)
                .ToList();

            return shuffledDeck;
        }
        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <param name="cards">The cards.</param>
        /// <returns></returns>

        public static Card GetCard(List<Card> cards)
        {
            var rand = new Random();
            Card card = cards[rand.Next(0, cards.Count - 1)];
            //if (card.CardNumber > 10)
            //{
            //    card.CardNumber = 10;
            //}

            return card;
        }


    }
}
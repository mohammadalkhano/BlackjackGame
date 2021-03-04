using BlackJackGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackGame
{
    public static class Deck
    {
        //private static string[] cards { get; set; } = new string[13] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Q", "J", "K" };
        //private static string[] cardType { get; set; } = new string[4] { "♥", "♣", "♠", "♦" };
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

                    gameDeck.Add(new Card(Cards[j], CardType[i]));

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
        /// <param name="deck">The deck.</param>
        /// <returns></returns>
        public static int GetCard1(string card)
        {
            /* Kan vi gör om klassen "Player" till static??? */
            Player player = new Player("");
            
            int cardValue;
            //string card = cards[^1];
            //var cardValue = card[0];
            //cards.RemoveAt(cards.Count - 1);

            if (card.StartsWith("Q") || card.StartsWith("K") ||
                card.StartsWith("J") || card.StartsWith("1"))
            {
                cardValue = 10;
            }
            else if (card.StartsWith("A"))
            {
                cardValue = player.Score + 11>21 ? 1 : 11;
            }
            else
            {
                var card = Deck.GetCard(list);
                //Output.ShowCards(card,card);
                Console.WriteLine(card.CardNumber + card.CardSymbol);

            }
            //DeckForGame. RemoveAt(DeckForGame.Count-1);
            return cardValue;
        }
        /// <summary>
        /// Gets the card.
        /// </summary>
        /// <param name="cards">The cards.</param>
        /// <returns></returns>
        public static Card GetCard(List<Card> cards)
        {
            /* Kan vi gör om klassen "Player" till static??? */
            Player player = new Player("");
            
            Card card = cards[^1];
            cards.RemoveAt(cards.Count - 1);
            return card;
        }

    }
}
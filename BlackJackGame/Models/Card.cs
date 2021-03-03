using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class Card : Deck
    {
        public int CardValue { get; set; }
        public  string CardType { get; set; }
        public static int[] CardsValueArray { get; set; } = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };


        public static Card CreateCard(int value, string type)
        {
            var newCard = new Card
            {
                CardValue = value,
                CardType = "type",
            };
            return newCard;
        }
        public static List<Card> CreateDeckOf52()
        {
            var deck = new List<Card>();
            

            for (int i = 0; i < cardType.Length; i++)
            {
                for (int j = 0; j < CardsValueArray.Length; j++)
                {
                    deck.Add(CreateCard(CardsValueArray[j], cardType[i]));
                }
            }

            return deck;
        }
        public static List<Card> CreateMultipleDecks(List<Card> deck, int numberOfDecks)
        {
            var newDeck = new List<Card>();
            for (int i = 0; i < numberOfDecks; i++)
            {
                foreach (var card in deck)
                {
                    newDeck.Add(card);
                }
            }
            return newDeck;
        } 
    }
}

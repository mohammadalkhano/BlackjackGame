﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class Card
    {
        //public enum ECardSymbol
        //{
        //    Club = '♥',
        //    Diamond = '♣',
        //    Heart = '♠',
        //    Spades = '♦',
        //}
        //public enum ECardNumber
        //{
        //    Ace = 1,
        //    Two = 2,
        //    Three = 3,
        //    Four = 4,
        //    Five = 5,
        //    Six = 6,
        //    Seven = 7,
        //    Eight = 8,
        //    Nine = 9,
        //    Ten = 10,
        //    Jack = 11,
        //    Queen = 12,
        //    King = 13,
        //}

        public string CardSymbol { get; set; }
        public int CardNumber { get; set; }

        public Card(int CardNumber, string CardSymbol)
        {
            this.CardNumber = CardNumber;
            this.CardSymbol = CardSymbol;
        }




    }
    public static class TestDecK
    {
        private static int[] Cards { get; set; } = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        private static string[] CardType { get; set; } = new string[4] { "♥", "♣", "♠", "♦" };
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
    }



}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BlackJack.GetCard(Deck.BuildDeckForGame(Deck.GenerateDeck())));
            Console.WriteLine(BlackJack.GetCard(Deck.BuildDeckForGame(Deck.GenerateDeck())));
            Console.WriteLine(BlackJack.GetCard(Deck.BuildDeckForGame(Deck.GenerateDeck())));
            Console.WriteLine(BlackJack.GetCard(Deck.BuildDeckForGame(Deck.GenerateDeck())));
            Console.WriteLine(BlackJack.GetCard(Deck.BuildDeckForGame(Deck.GenerateDeck())));
            Console.WriteLine(BlackJack.GetCard(Deck.BuildDeckForGame(Deck.GenerateDeck())));
            Console.WriteLine(BlackJack.GetCard(Deck.BuildDeckForGame(Deck.GenerateDeck())));
            
            //Game.RunGame();

        }
    }
}

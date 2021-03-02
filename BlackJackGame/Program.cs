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
            //Game.RunGame();
            for (int i = 0; i < 10; i++)
            {
               
                Console.Write("Card value: "+Deck.GetCard(Deck.GetCardString(Deck.deckForGame))+", Card symbol: "+ Deck.GetCardString(Deck.deckForGame));
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine();
            }

            Console.Read();

        }
    }
}

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
            Console.WriteLine("CHECK_Mohammad_KH_Branch\n");
            Deck deck = new Deck();
            var list = deck.GenerateDeck();
            var deeck = deck.BuildDeckForGame(list);
            deck.GetCard(deeck);

            /*To check the card*/
            //if (item.StartsWith("Q") || item.StartsWith("J") || item.StartsWith("K"))
            //{
            //    Console.WriteLine("*10*");
            //}
            //else if (item.StartsWith("A"))
            //{
            //    Console.WriteLine("1 or 11");
            //}
            //else
            //{
            //    /*----Used to get the symbol printed when you print the list---*/
            //    Console.OutputEncoding = Encoding.UTF8;
            //   // Console.WriteLine(item);

            //}
            Console.Read();
        }
    }
}

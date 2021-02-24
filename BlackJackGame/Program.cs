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
            
            Console.WriteLine("Hello World!");


            Deck deck = new Deck();
            var list = deck.GetCard(deck.GenerateCard());
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}

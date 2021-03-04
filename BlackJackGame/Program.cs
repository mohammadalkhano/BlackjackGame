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

            //var list = Models.TestDecK.CreateMultipleDecks(Models.TestDecK.GetDeck(), 4);
            //var listLength = list.Count;
            //Console.WriteLine(listLength);
            Game.RunGame();
            Console.Read();


        }
    }
}

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
            Console.OutputEncoding= Encoding.UTF8;
    
            //var listLength = list.Count;
            //Console.WriteLine(listLength);
            //foreach (var item in list)
            //{
            //    if (item.CardNumber == 1)
            //        Console.WriteLine("A" + item.CardSymbol);

            //    else if (item.CardNumber == 11)
            //        Console.WriteLine("J" + item.CardSymbol);

            //    else if (item.CardNumber == 12)
            //        Console.WriteLine("Q" + item.CardSymbol);


            //    else if (item.CardNumber == 13)
            //        Console.WriteLine("K" + item.CardSymbol);

            //    else
            //        Console.WriteLine(item.CardNumber + item.CardSymbol);
            //}
            //var list = Deck.CardsForGame;
            //for (int i = 0; i < 208; i++)
            //{
            //    var card= Deck.GetCard(list);
            //    //Output.ShowCards(card,card);
            //    Console.WriteLine(card.CardNumber+card.CardSymbol);

            //}

            Console.SetWindowSize(120, 40);


            Game.RunGame();


        }
    }
}

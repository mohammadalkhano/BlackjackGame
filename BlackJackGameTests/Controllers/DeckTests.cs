using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackJackGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        public void BuildDeckForGameTest()
        {
            var list = new List<string>() { "A", "C", "D" };
            var expected = 12;
            //var actual = Deck.BuildDeckForGame(list);
            //Assert.AreEqual(expected, actual.Count());
        }
        [TestMethod()]
        public void BuildDeckForGameTestWithGenerateDeck()
        {
            //var list = Deck.GenerateDeck();
            var expected = 208;
            //var actual = Deck.BuildDeckForGame(list);
           // Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod()]
        public void GetCardTest_Q_J_K()
        {
            //var list = Deck.SuffleList(Deck.BuildDeckForGame(Deck.GenerateDeck()))
            var card = "Q" ;
            int expected = 10;
            var actual = Deck.GetCard(card);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        //public void GetCardTest_A()
        //{
        //    //var list = Deck.SuffleList(Deck.BuildDeckForGame(Deck.GenerateDeck()))
        //    var list = new List<string>() { "A" };
        //    int expected = 1;
        //    var actual = Deck.GetCard(list);
        //    Assert.AreEqual(expected, actual);
        //}
        public void GetCardTest_Num()
        {
            //var list = Deck.SuffleList(Deck.BuildDeckForGame(Deck.GenerateDeck()))
            var card =  "3";
            int expected = 3;
            var actual = Deck.GetCard(card);
            Assert.AreEqual(expected, actual);
        }
        /*Testar metoden om den ska retunera random list :) EJ Klar!*/
        //[TestMethod()]
        //public void SuffleListTest()
        //{
        //    var list = Deck.GenerateDeck();
        //    var deek= Deck.BuildDeckForGame(list);

        //    var notExpected = deek;
        //    var actual = Deck.SuffleList(deek);
        //    Assert.AreEqual(notExpected, actual);
        //}
    }
}
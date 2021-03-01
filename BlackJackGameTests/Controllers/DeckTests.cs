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
        public void GenerateCardTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void GetCardTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ResetCardsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuildDeckForGameTest()
        {
            var list = new List<string>() { "A", "C", "D" };
            var expected = 12;
            var actual = Deck.BuildDeckForGame(list);
            Assert.AreEqual(expected, actual.Count());
        }
        [TestMethod()]
        public void BuildDeckForGameTestWithGenerateDeck()
        {
            var list = Deck.GenerateDeck();
            var expected = 208;
            var actual = Deck.BuildDeckForGame(list);
            Assert.AreEqual(expected, actual.Count());
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
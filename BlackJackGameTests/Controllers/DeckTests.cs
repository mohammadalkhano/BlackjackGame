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
        public void GetDeckTest_52Cards()
        {
            Assert.AreEqual(52, Deck.GetDeck().Count);
        }

        [TestMethod()]
        public void GetDeckTest_52CardsFail()
        {
            Assert.AreEqual(false, Deck.GetDeck().Count == 50);
        }
        [TestMethod()]
        public void CreateMultipleDecksTest_FourDecks()
        {
            Assert.AreEqual((52 * 4), Deck.CreateMultipleDecks(Deck.GetDeck(), 4).Count);
        }
        [TestMethod()]
        public void CreateMultipleDecksTest_FourDecksFail()
        {
            Assert.AreEqual(false, Deck.CreateMultipleDecks(Deck.GetDeck(), 4).Count == 200);
        }

        [TestMethod()]
        public void GetCardTest_ReturnsOneCard()
        {
            var list = Deck.GetDeck();
            Assert.AreEqual(typeof(Models.Card), Deck.GetCard(list).GetType()); 
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BlackJackGame.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        //Tests the GetDeck if it generates the deck of 52 Cards.
        public void GetDeckTest_52Cards()
        {
            Assert.AreEqual(52, Deck.GetDeck().Count);
        }

        [TestMethod()]
        //Tests the GetDeck if it generates the deck of 52 Cards or not.
        public void GetDeckTest_52CardsFail()
        {
            Assert.AreEqual(false, Deck.GetDeck().Count == 50);
        }
        [TestMethod()]
        //Tests the CreateMultipleDecks if it generates the multiple deck of 52*4 Cards.
        public void CreateMultipleDecksTest_FourDecks()
        {
            Assert.AreEqual((52 * 4), Deck.CreateMultipleDecks(Deck.GetDeck(), 4).Count);
        }
        [TestMethod()]
        //Tests the CreateMultipleDecks if it generates the multiple deck of 52*4 Cards.
        public void CreateMultipleDecksTest_FourDecksFail()
        {
            Assert.AreEqual(false, Deck.CreateMultipleDecks(Deck.GetDeck(), 4).Count == 200);
        }
        //Checks the GetCard if it return one card of "Card" type(compare two objects if they are of the same type).
        [TestMethod()]
        public void GetCardTest_ReturnsOneCard()
        {
            var list = Deck.GetDeck();
            Assert.AreEqual(typeof(Models.Card), Deck.GetCard(list).GetType()); 
        }
    }
}
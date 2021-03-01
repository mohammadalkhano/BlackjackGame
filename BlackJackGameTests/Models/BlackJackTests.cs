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
    public class BlackJackTests
        {
        [TestMethod()]
        public void SeclectPlayersReturnInput()
            {

            var actual = BlackJack.SeclectPlayers(2);
            var expected = 2;
            Assert.AreEqual(expected,actual);

            }


        [TestMethod()]
        public void SeclectPlayersTooLow()
            {

            var actual = BlackJack.SeclectPlayers(-2);
            Assert.AreEqual( 1,actual); // vi förvänter att den ska bli 1 ,the som vi för från metoden

            }
        [TestMethod()]
        public void SeclectPlayersTooHigh()
            {

            var actual = BlackJack.SeclectPlayers(10);
            
            Assert.AreEqual( 7,actual);

            }
        [TestMethod()]
        public void SelectTableMoreThanFour()
            {
            var actual = BlackJack.SelectTable(10);
            Assert.AreEqual(4, actual);// vi för vänta oss 4, actual det man får från metoden
            }
        [TestMethod()]
        public void SelectTableLessThanOne()
            {
            var actual = BlackJack.SelectTable(-1);
            Assert.AreEqual(1,actual);
            }
        [TestMethod()]
        public void SelectTableTwo()
            {
            var actual = BlackJack.SelectTable(2);
            Assert.AreEqual(2,actual);
            }


        }

    }
    
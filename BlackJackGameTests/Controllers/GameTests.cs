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
    public class GameTests
    {
        /// <summary>
        /// String value is returned based on player total score
        /// </summary>
        [TestMethod()]
        //Player score is set to 1
        public void SetProTipTest_PlayerScore1()
        {
            var p = new Player("Player X");
            p.Score = 1;
            Assert.AreEqual("You should really take one more card!", Game.SetProTip(p));
        }
        //Player score is set to 15
        [TestMethod()]
        public void SetProTipTest_PlayerScore15()
        {
            var p = new Player("Player X");
            p.Score = 15;
            Assert.AreEqual("Maybe ONE more card..?", Game.SetProTip(p));
        }
        //Player score is set to 30
        [TestMethod()]
        public void SetProTipTest_PlayerScore30()
        {
            var p = new Player("Player X");
            p.Score = 30;
            Assert.AreEqual("For the love of God, STAY!", Game.SetProTip(p));
        }
    }
}

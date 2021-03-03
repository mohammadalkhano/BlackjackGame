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
    public class PlayerTests
    {
        [TestMethod()]
        public void CreatePlayerTest()
        {
           var actul = Player.CreatePlayer(7).Count;
            Assert.AreEqual(8,actul); // + huset  
        }
    }
}
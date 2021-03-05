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
        public void CreatePlayerTest_Correct()
            {
            Assert.AreEqual(5,Player.CreatePlayer(4).Count);
            Assert.AreEqual(true,Player.CreatePlayer(15).Count == 16);
            }
        [TestMethod()]
        public void CreatePlayerTest_InCorrect()
            {
            Assert.AreEqual(false,(Player.CreatePlayer(4).Count == 4));
            }
        [TestMethod()]
        public void CreatePlayerTest_PlayerName()
            {
            var List = Player.CreatePlayer(4);
            Assert.AreEqual("Player 1",List[0].Name);
            }
        [TestMethod()]
        public void CreatePlayerTest_HouseName()
            {
            var List = Player.CreatePlayer(4);
            Assert.AreEqual("House",List[4].Name);
            }
        }
    }
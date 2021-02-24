using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJackGame
{
    public class Player
    {
        //Man kan inte deklarera variable eller prop i var typ! "var" type används bara inne i metoder.
        //public var cards { get; set; }
        //public var total { get; set; }
        //public var playerName { get; set; }
        public string playerName { get; set; }
        public int amount { get; set; }
        public Player()
        {
            
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class Card
    {

        public string CardSymbol { get; set; }
        public int CardNumber { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="CardNumber"></param>
        /// <param name="CardSymbol"></param>
        public Card(int CardNumber, string CardSymbol)
        {
            this.CardNumber = CardNumber;
            this.CardSymbol = CardSymbol;
        }

    }
    



}


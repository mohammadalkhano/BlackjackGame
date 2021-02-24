using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    public interface IBlackJack
    {
        /// <summary>
        ///Declare our methods here! Then implements the interface.
        /// </summary>
        public void CreatePlayer();
        public void ResetDeck();
        public void GiveCard();
        public void RunGame();
        public int SeclectNumberOfPlayers();
        public int SelectTable();

        //Kortlek
        //Antal kortlekar
        //Kort[]
        //ResetCards(List<Players>) – raderar alla kort från spelarna och nollställer kortleken
        //GetCard() – drar ett kort ur kortleken(tar bort den ur kortleken)
    }
}

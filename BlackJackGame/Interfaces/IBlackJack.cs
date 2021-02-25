namespace BlackJackGame
{
    public interface IBlackJack
    {
        /// <summary>
        ///Declare our methods here! Then implements the interface.
        /// </summary>
        void CreatePlayer();
        void ResetDeck();
        void GiveCard();
        void RunGame();
        int SeclectPlayers();
        int SelectTable();


    }
}

namespace KMorcinek.TheCityCardGame
{
    public interface IGameServer
    {
        int Connect();
        IPlayer GetState(int playerIndex);
        void PlayCard(int playerIndex, int cardIndexToPlay, int[] cardsToDiscard);
        void PlayArchitect(int playerIndex);
    }
}
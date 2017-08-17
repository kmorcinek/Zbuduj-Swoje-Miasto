using KMorcinek.TheCityCardGame.SharedDtos;

namespace KMorcinek.TheCityCardGame
{
    public interface IGameServer
    {
        int Connect();
        IPlayer GetState(int playerIndex);
        void PlayCard(int playerIndex, int cardIndexToPlay, int[] cardsToDiscard);
        void PlayArchitect(int playerIndex);
        See5CardsDto See5Cards(int playerIndex);
    }
}
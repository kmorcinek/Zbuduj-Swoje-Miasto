using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame
{
    public interface IPlayer
    {
        IEnumerable<Card> CardsInHand { get; }
        IEnumerable<Card> PlayedCards { get; }
        int Points { get; }
        int Turn { get; }
    }
}
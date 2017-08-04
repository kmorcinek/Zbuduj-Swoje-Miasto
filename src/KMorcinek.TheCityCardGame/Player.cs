using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame
{
    public class Player
    {
        public IEnumerable<Card> CardsInHand { get; }
        public IEnumerable<Card> PlayedCards { get; }

        public Player(IEnumerable<Card> cardsInHand, IEnumerable<Card> playedCards)
        {
            CardsInHand = cardsInHand;
            PlayedCards = playedCards;
        }
    }
}
using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame
{
    public class Player
    {
        public IEnumerable<Card> CardsInHand { get; private set; }
        public IEnumerable<Card> PlayedCards { get; private set; }

        public Player(IEnumerable<Card> cardsInHand, IEnumerable<Card> playedCards)
        {
            CardsInHand = cardsInHand;
            PlayedCards = playedCards;
        }
    }
}
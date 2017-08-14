using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Player
    {
        public IEnumerable<Card> CardsInHand { get; }

        public IEnumerable<Card> PlayedCards => _playedCards;

        readonly RequiredCardsCalculator _requiredCardsCalculator;
        readonly LinkedList<Card> _playedCards;

        public Player()
        {
            _requiredCardsCalculator = new RequiredCardsCalculator();
            _playedCards = new LinkedList<Card>();
        }

        public void PlayCard(int cardIndex)
        {
            if (cardIndex >= CardsInHand.Count())
            {
                throw new ArgumentOutOfRangeException(nameof(cardIndex));
            }

            var playedCard = CardsInHand.ElementAt(cardIndex);
            if (_requiredCardsCalculator.CanBePlayed(playedCard, this) == false)
            {
                throw new InvalidOperationException("Cannot play this card");
            }
        }

        public void UpdatePoints()
        {
            throw new NotImplementedException();
        }
    }
}
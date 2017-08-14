using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Player
    {
        const int HandCapacity = 12;

        public IEnumerable<Card> CardsInHand => _cardsInHand;
        public IEnumerable<Card> PlayedCards => _playedCards;

        readonly RequiredCardsCalculator _requiredCardsCalculator;
        readonly LinkedList<Card> _playedCards;
        readonly List<Card> _cardsInHand;

        public Player(IEnumerable<Card> startingCards)
        {
            _requiredCardsCalculator = new RequiredCardsCalculator();
            _playedCards = new LinkedList<Card>();
            _cardsInHand = new List<Card>(HandCapacity);
            _cardsInHand.AddRange(startingCards);
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

            _cardsInHand.Remove(playedCard);
            _playedCards.AddLast(playedCard);
        }

        public void UpdatePoints()
        {
            throw new NotImplementedException();
        }
    }
}
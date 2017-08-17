using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace KMorcinek.TheCityCardGame
{
    public class Player : IPlayer
    {
        const int HandCapacity = 12;
        public const int PointsGoal = 50;

        public IEnumerable<Card> CardsInHand => _cardsInHand;
        public IEnumerable<Card> PlayedCards => _playedCards;

        public int Points => _points;
        public int Turn => _turn;

        readonly RequiredCardsCalculator _requiredCardsCalculator;
        readonly LinkedList<Card> _playedCards;
        readonly List<Card> _cardsInHand;
        int _points;
        int _turn;

        public Player(IEnumerable<Card> startingCards)
        {
            _requiredCardsCalculator = new RequiredCardsCalculator();
            _playedCards = new LinkedList<Card>();
            _cardsInHand = new List<Card>(HandCapacity);
            _cardsInHand.AddRange(startingCards);
        }

        public static Player CreateWithPlayedCards(params Card[] cards)
        {
            var player = new Player(Enumerable.Empty<Card>());

            foreach (var card in cards)
            {
                player._playedCards.AddLast(card);
            }

            return player;
        }

        public void PlayCard(int cardIndex, IEnumerable<int> cardsToDiscard)
        {
            if (cardIndex >= CardsInHand.Count())
            {
                throw new ArgumentOutOfRangeException(nameof(cardIndex));
            }

            var playedCard = CardsInHand.ElementAt(cardIndex);

            _requiredCardsCalculator.EnsureCanBePlayed(playedCard, this);

            if (cardsToDiscard.Distinct().Count() != cardsToDiscard.Count())
            {
                throw new InvalidOperationException("Cannot discard the same card");
            }

            if (cardsToDiscard.Contains(cardIndex))
            {
                throw new InvalidOperationException("Cannot discard played card");
            }

            foreach (var indexToDiscard in cardsToDiscard.Reverse())
            {
                _cardsInHand.RemoveAt(indexToDiscard);
            }

            Log.Debug("Played card: {card}", playedCard.CardEnum);

            _cardsInHand.Remove(playedCard);
            _playedCards.AddLast(playedCard);
        }

        public void UpdatePoints()
        {
            var newPoints = new WinningPointsCalculator().Calculate(PlayedCards);

            _points += newPoints;

            _turn++;
        }

        public void AddDealtCards(IEnumerable<Card> cards)
        {
            _cardsInHand.AddRange(cards);
        }

        public void PlayArchitect()
        {
            _playedCards.AddLast(Card.Architect);
        }

        public bool IsWinner()
        {
            return Points >= PointsGoal;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Game
    {
        private readonly RequiredCardsCalculator _requiredCardsCalculator;
        private readonly Calculator _calculator;
        private readonly CardsDealer _cardsDealer;

        public Game(
            RequiredCardsCalculator requiredCardsCalculator,
            Calculator calculator,
            CardsDealer cardsDealer)
        {
            _requiredCardsCalculator = requiredCardsCalculator;
            _calculator = calculator;
            _cardsDealer = cardsDealer;
        }

        public Board StartGame()
        {
            throw new NotImplementedException("UI needed");
            var cardsInHand = Deck.GetShuffledDeck();
            var player = new Player(DealStartingCards(cardsInHand), Enumerable.Empty<Card>());
            var board = new Board(player, cardsInHand);
            return board;
        }

        public Board NextTurn(Board board, int cardIndex)
        {
            if (cardIndex >= board.Player.CardsInHand.Count())
                throw new ArgumentOutOfRangeException("cardIndex");

            var playedCard = board.Player.CardsInHand.ElementAt(cardIndex);
            if (_requiredCardsCalculator.CanBePlayed(playedCard, board.Player) == false)
                throw new InvalidOperationException("Cannot play this card");

            var remainInHand = board.Player.CardsInHand.Where(card => card != playedCard);
            var justPlayedHand = board.Player.PlayedCards.Concat(new[] { playedCard }).ToList();

            var newBoard = new Board(
                new Player(remainInHand, justPlayedHand), board.Deck);

            return _cardsDealer.DealNewCards(newBoard);
        }

        public int Play()
        {
            //var remainingCards = new Deck(new Card[0]);

            //var firstPlayer = new Player(DealStartingCards(remainingCards));

            //while (true)
            //{
            //    PlayCard(firstPlayer, remainingCards);
            //    const int winingLimit = 20;
            //    if (_calculator.CalculateWinningPoints(firstPlayer.PlayedCards) > winingLimit)
            //    {
            //        return 1;
            //    }
            //}
            return 1;
        }

        //private void PlayCard(Player player, Deck deck)
        //{
        //    var choosenCard = player.CardsInHand.FirstOrDefault(card =>
        //        _requiredCardsCalculator.CanBePlayed(card, player)
        //        );

        //    if (choosenCard != null)
        //    {
        //        player.CardsInHand.Remove(choosenCard);
        //        player.PlayedCards.Add(choosenCard);
        //        player.CardsInHand.Add(deck.Pop());
        //    }
        //    else
        //    {
        //        player.CardsInHand.Add(deck.Pop());
        //        player.CardsInHand.Add(deck.Pop());
        //    }
        //}

        private static IEnumerable<Card> DealStartingCards(Deck deck)
        {
            return deck.Take(4);
        }
    }
}
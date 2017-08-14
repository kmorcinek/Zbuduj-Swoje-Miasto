using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Game
    {
        private readonly Calculator _calculator;

        public static Game Create()
        {
            return new Game(null);
        }

        public Game(Calculator calculator)
        {
            _calculator = calculator;
        }

        public Board StartGame()
        {
            var wholeDeck = Deck.GetShuffledDeck();
            var player = new Player();
            
            // TODO: Board should not take wholeDeck
            var board = new Board(player, wholeDeck);
            return board;
        }

        public void NextTurn(Board board, int cardIndex)
        {
            // Play card
            board.Player.PlayCard(cardIndex);

            // Count points
            board.Player.UpdatePoints();

            // Draw new cards
            DrawNewCards(board, board.Player);
        }

        void DrawNewCards(Board board, Player player)
        {
            throw new NotImplementedException();
            //var cardsToDeal = HowManyCanDeal(board.Player.PlayedCards);
            //var newPlayer = new Player(board.Player.CardsInHand.Concat(board.Deck.Take(cardsToDeal)), board.Player.PlayedCards);

            //var newBoard = new Board(newPlayer, board.Deck.Skip(cardsToDeal));
        }

        public int HowManyCanDeal(IEnumerable<Card> playedCards)
        {
            return playedCards.Sum(c => c.CashPoints);
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
            return deck.Take(5);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class CardsDealer
    {
        // CardsDealerCalculator
        public Board DealNewCards(Board board)
        {
            var cardsToDeal = HowManyCanDeal(board.Player.PlayedCards);
            var newPlayer = new Player(board.Player.CardsInHand.Concat(board.Deck.Take(cardsToDeal)), board.Player.PlayedCards);

            var newBoard = new Board(newPlayer, board.Deck.Skip(cardsToDeal));
            return newBoard;
        }

        public int HowManyCanDeal(IEnumerable<Card> playedCards)
        {
            return playedCards.Sum(c => c.CashPoints);
        }
    }
}
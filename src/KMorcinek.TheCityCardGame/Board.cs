using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Board
    {
        public Player Player { get; }
        public IEnumerable<Card> Deck { get; }

        public Board(Player player, IEnumerable<Card> deck)
        {
            Player = player;
            Deck = deck;
        }

        public void NextTurn(int cardIndex, IEnumerable<int> cardsToDiscard)
        {
            // Play card
            Player.PlayCard(cardIndex, cardsToDiscard);

            // Count points
            Player.UpdatePoints();

            // Draw new cards
            DrawNewCards(Player);
        }

        void DrawNewCards(Player player)
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
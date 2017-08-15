using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Board
    {
        public Deck Deck { get; }
        public Player Player { get; }

        public Board(Deck deck, Player player)
        {
            Deck = deck;
            Player = player;
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

        public void DrawNewCards(Player player)
        {
            int cardsToDeal = HowManyCanDeal(player.PlayedCards);

            List<Card> cards = new List<Card>(cardsToDeal);

            for (int i = 0; i < cardsToDeal; i++)
            {
                cards.Add(Deck.Pop());
            }

            // TODO: can not deal more than 12
            player.AddDealtCards(cards);
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
    }
}
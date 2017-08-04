using System;
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Board
    {
        public Deck Deck { get; }
        public IEnumerable<Player> Players { get; }

        public Board(Deck deck, params Player[] players)
        {
            Deck = deck;
            Players = players;
        }

        public void PlayCard(int playerIndex, int cardIndex, IEnumerable<int> cardsToDiscard)
        {
            // Play card
            Players.ElementAt(playerIndex).PlayCard(cardIndex, cardsToDiscard);

            // Count points
            Players.ElementAt(playerIndex).UpdatePoints();

            // Draw new cards
            DrawNewCards(Players.ElementAt(playerIndex));
        }

        public void DrawNewCards(Player player)
        {
            int cardsToDeal = new CashPointsCalculator().HowManyCashPoints(player.PlayedCards);

            List<Card> cards = new List<Card>(cardsToDeal);

            for (int i = 0; i < cardsToDeal; i++)
            {
                cards.Add(Deck.Pop());
            }

            // TODO: can not deal more than 12
            player.AddDealtCards(cards);
        }

    }
}
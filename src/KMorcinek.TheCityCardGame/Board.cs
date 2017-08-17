using System;
using System.Collections.Generic;
using System.Linq;
using KMorcinek.TheCityCardGame.SharedDtos;

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

        public static Board StartGame(int playersCount)
        {
            Deck wholeDeck = Deck.GetShuffledDeck();

            var players = new List<Player>();
            for (int i = 0; i < playersCount; i++)
            {
                players.Add(new Player(DrawStartingHand(wholeDeck)));
            }

            return new Board(wholeDeck, players.ToArray());
        }

        static IEnumerable<Card> DrawStartingHand(Deck wholeDeck)
        {
            return DrawCards(wholeDeck, 5);
        }

        public static IEnumerable<Card> DrawCards(Deck wholeDeck, int count)
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                cards.Add(wholeDeck.Pop());
            }

            return cards;
        }

        public void PlayArchitect(int playerIndex)
        {
            // Play card
            Players.ElementAt(playerIndex).PlayArchitect();

            // Count points
            Players.ElementAt(playerIndex).UpdatePoints();

            // Draw new cards
            DrawNewCards(Players.ElementAt(playerIndex));
        }

        public IEnumerable<Card> DrawAndSee5Cards()
        {
            // TODO: implemet 5 cards shown to who
            return DrawCards(Deck, 5);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

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
            Player player = Players.ElementAt(playerIndex);

            player.PlayCard(cardIndex, cardsToDiscard);

            UpdatePointsAndDrawCards(player);
        }

        void UpdatePointsAndDrawCards(Player player)
        {
            player.UpdatePoints();

            DrawNewCards(new CashPointsCalculator(), player);
        }

        public void DrawNewCards(ICashPointsCalculator cashPointsCalculator, Player player)
        {
            int cardsToDeal = cashPointsCalculator.HowManyCashPoints(player.PlayedCards);

            cardsToDeal = Math.Min(cardsToDeal, Player.HandCapacity - player.CardsInHand.Count());

            player.AddDealtCards(DrawCards(Deck, cardsToDeal));
        }

        public static Board StartGame(int playersCount)
        {
            Deck wholeDeck = Deck.GetShufledDeck();

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
            Player player = Players.ElementAt(playerIndex);

            player.PlayArchitect();

            UpdatePointsAndDrawCards(player);
        }

        public void TakeOneCard(int playerIndex, Card card)
        {
            Log.Debug("Player chooses card {card}", card.CardEnum.ToString());

            Player player = Players.ElementAt(playerIndex);

            player.AddDealtCards(new[] { card });

            UpdatePointsAndDrawCards(player);
        }

        public IEnumerable<Card> DrawAndSee5Cards()
        {
            // TODO: implement 5 cards shown to who
            return DrawCards(Deck, 5);
        }
    }
}
using System.Collections.Generic;

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
    }
}
using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame
{
    public class Board
    {
        public Player Player { get; private set; }
        public IEnumerable<Card> Deck { get; private set; }

        public Board(Player player, IEnumerable<Card> deck)
        {
            Player = player;
            Deck = deck;
        }
    }
}
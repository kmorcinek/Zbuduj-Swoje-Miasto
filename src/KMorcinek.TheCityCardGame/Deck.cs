using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame
{
    public class Deck : Stack<Card>
    {
        Deck(Card[] cards)
            : base(cards)
        {
        }

        public static Deck GetShuffledDeck()
        {
            var deck = new Card[]
            {
                Card.Park,
                Card.House,
                Card.Parking,
                Card.TradeCenter,
                Card.House,
                Card.Parking,
                Card.TradeCenter,
                Card.House,
                Card.Parking,
                Card.TradeCenter,
                Card.Park,
                Card.OfficeBuilding,
            };

            //TODO: shuffle them

            return new Deck(deck);
        }

        void Foo()
        {
            Dictionary<Card, int> cards = new Dictionary<Card, int>
            {
                { Card.Parking, 4 },
                { Card.House, 3 }
            };

        }
    }
}
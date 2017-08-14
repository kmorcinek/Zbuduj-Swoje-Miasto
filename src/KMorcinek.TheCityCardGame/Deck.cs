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
                Card.House,
                Card.Parking,
                Card.TradeCenter,
                Card.House,
                Card.Parking,
                Card.TradeCenter,
                Card.House,
                Card.Parking,
                Card.TradeCenter,
            };

            //TODO: shuffle them

            return new Deck(deck);
        }
    }
}
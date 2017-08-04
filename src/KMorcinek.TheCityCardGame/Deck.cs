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
                Card.Busbahnhof,
                Card.Wohnhaus,
                Card.Busbahnhof,
                Card.Wohnhaus,
                Card.Busbahnhof,
                Card.Wohnhaus,
                Card.Busbahnhof,
                Card.Wohnhaus,
            };

            //TODO: shuffle them

            return new Deck(deck);
        }
    }
}
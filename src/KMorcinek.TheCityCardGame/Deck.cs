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
                Card.BusStation,
                Card.BusinessCenter,
                Card.Cinema, 
                Card.CityHall, 
                Card.BusStation,
                Card.BusinessCenter,
                Card.Cinema, 
                Card.CityHall, 
                Card.BusStation,
                Card.BusinessCenter,
                Card.Cinema, 
                Card.CityHall, 
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
                // 1
                //{ Card.House, 3 }
                //{ Card.Parking, 4 },
                { Card.School, 44 },

                // 2

            };

        }
    }
}
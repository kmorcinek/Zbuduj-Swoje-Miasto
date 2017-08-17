using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace KMorcinek.TheCityCardGame
{
    public class Deck : Stack<Card>
    {
        Deck(Card[] cards)
            : base(cards)
        {
        }

        public static Deck GetHardcodedDeck()
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

            return new Deck(deck);
        }

        public static Deck GetShufledDeck()
        {
            List<Card> allCardsForDeck = GetAllCardsForDeck().AsEnumerable().ToList();
            int upperBound = allCardsForDeck.Count;

            Random random = new Random();

            List<Card> shuffled = new List<Card>(allCardsForDeck.Count);

            while (upperBound > 0)
            {
                int next = random.Next(upperBound);

                shuffled.Add(allCardsForDeck[next]);
                allCardsForDeck.RemoveAt(next);

                upperBound--;
            }

            return new Deck(shuffled.ToArray());
        }

        // TODO: Type Initializer error on below line
        //// readonly IEnumerable<Card> AllCardsForDeck = GetAllCardsForDeck();

        static List<Card> GetAllCardsForDeck()
        {
            return Instance.SelectMany(x => Enumerable.Repeat(x.Value.Card, x.Value.Quantity)).ToList();
        }

        static readonly Dictionary<CardEnum, CardWithQuantity> Instance = Create();

        static Dictionary<CardEnum, CardWithQuantity> Create()
        {
            var cards = new Dictionary<CardEnum, CardWithQuantity>
            {
                ////{ CardEnum.Architect, new CardWithQuantity(Card.Architect, 2) },
                // 0
                { CardEnum.Parking, new CardWithQuantity(Card.Parking, 2) },

                // 1
                { CardEnum.BusStation, new CardWithQuantity(Card.BusStation, 2) },
                { CardEnum.ConstructionCrew, new CardWithQuantity(Card.ConstructionCrew, 2) },
                { CardEnum.House, new CardWithQuantity(Card.House, 2) },
                { CardEnum.Housing, new CardWithQuantity(Card.Housing, 2) },
                { CardEnum.IndastrialPark, new CardWithQuantity(Card.IndastrialPark, 2) },
                { CardEnum.Park, new CardWithQuantity(Card.Park, 2) },
                { CardEnum.Private, new CardWithQuantity(Card.Private, 2) },
                { CardEnum.Restaurant, new CardWithQuantity(Card.Restaurant, 2) },
                { CardEnum.School, new CardWithQuantity(Card.School, 2) },
                { CardEnum.Supermarket, new CardWithQuantity(Card.Supermarket, 2) },

                // 2
                ////{ CardEnum.Butique, new CardWithQuantity(Card.Butique, 2) },
                { CardEnum.Cinema, new CardWithQuantity(Card.Cinema, 2) },
                { CardEnum.CityHall, new CardWithQuantity(Card.CityHall, 2) },
                { CardEnum.OfficeBuilding, new CardWithQuantity(Card.OfficeBuilding, 2) },
                { CardEnum.RoadConnection, new CardWithQuantity(Card.RoadConnection, 2) },

                // 3
                { CardEnum.BusinessCenter, new CardWithQuantity(Card.BusinessCenter, 2) },
                { CardEnum.TradeCenter, new CardWithQuantity(Card.TradeCenter, 2) },

                // 4
                { CardEnum.Multiplex, new CardWithQuantity(Card.Multiplex, 2) },
                ////{ CardEnum.ResearchCenter, new CardWithQuantity(Card.ResearchCenter, 2) },
                ////{ CardEnum.Villa, new CardWithQuantity(Card.Villa, 2) },
            };

            CheckForBugs(cards);

            return cards;
        }

        static void CheckForBugs(Dictionary<CardEnum, CardWithQuantity> dict)
        {
            IEnumerable<CardEnum> cards = dict.Select(x => x.Value.Card.CardEnum);

            if (cards.Distinct().Count() != dict.Count)
            {
                throw new InvalidOperationException("Something wrong with Card definitions");
            }
        }

        public static Card GetCard(CardEnum cardEnum)
        {
            return Instance[cardEnum].Card;
        }

        struct CardWithQuantity
        {
            public Card Card { get; }
            public int Quantity { get; }

            public CardWithQuantity(Card card, int quantity)
            {
                Card = card;
                Quantity = quantity;
            }
        }
    }
}
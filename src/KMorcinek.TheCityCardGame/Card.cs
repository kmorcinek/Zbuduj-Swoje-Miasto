using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Card
    {
        public CardEnum CardEnum { get; }
        public int Cost { get; }
        public int CashPoints { get; }
        public int WinPoints { get; }
        public IEnumerable<Card> RequiredCards { get; }
        public int CommercePoints { get; }
        public int EnjoyPoints { get; }
        public int CarPoints { get; }
        public CardEnum? OneExtraCashPoint { get; } 

        public Card(CardEnum cardEnum, int cost, int cashPoints, int winPoints, IEnumerable<Card> requiredCards = null, int commercePoints = 0, int enjoyPoints = 0, int carPoints = 0, CardEnum? oneExtraCashPoint = null)
        {
            CardEnum = cardEnum;
            Cost = cost;
            CashPoints = cashPoints;
            WinPoints = winPoints;
            RequiredCards = requiredCards ?? Enumerable.Empty<Card>();
            CommercePoints = commercePoints;
            EnjoyPoints = enjoyPoints;
            CarPoints = carPoints;
            OneExtraCashPoint = oneExtraCashPoint;
        }

        public static Card Busbahnhof => new Card(CardEnum.Busbahnhof, 1, 0, 1, null, 1, 1 );
        public static Card Wohnhaus => new Card(CardEnum.Wohnhaus, 1, 1, 0);
        public static Card Freizeitpark => new Card(CardEnum.Freizeitpark, 8, 2, 5);
        public static Card Parking => new Card(CardEnum.Parking, 0, 0, 0);
    }
}
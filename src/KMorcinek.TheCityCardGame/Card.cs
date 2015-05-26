using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Card
    {
        public CardEnum CardEnum { get; private set; }
        public int Cost { get; private set; }
        public int CashPoints { get; private set; }
        public int WinPoints { get; private set; }
        public IEnumerable<Card> RequiredCards { get; private set; }
        public int CommercePoints { get; private set; }
        public int EnjoyPoints { get; private set; }
        public int CarPoints { get; private set; }
        public CardEnum? OneExtraCashPoint { get; private set; } 

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

        public static Card Busbahnhof
        {
            get { return new Card(CardEnum.Busbahnhof, 1, 0, 1, null, 1, 1 ); }
        }

        public static Card Wohnhaus
        {
            get { return new Card(CardEnum.Wohnhaus, 1, 1, 0); }
        }
    }
}
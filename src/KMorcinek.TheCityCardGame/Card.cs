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
        public Symbol? ExtraPointsPerSymbol { get; }

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

        public static Card Parking => new Card(CardEnum.Parking, 0, 0, 0);
        public static Card House => new Card(CardEnum.House, 1, 1, 0);
        public static Card TradeCenter => new Card(CardEnum.TradeCenter, 3, 1, 1);
        public static Card Park => new Card(CardEnum.Park, 1, 0, 0);
    }
}
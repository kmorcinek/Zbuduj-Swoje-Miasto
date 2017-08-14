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
        public IEnumerable<CardEnum> RequiredCards { get; }
        public IEnumerable<Symbol> Symbols { get; }
        public CardEnum? OneExtraCashPoint { get; }
        public Symbol? ExtraPointsPerSymbol { get; }

        public Card(
            CardEnum cardEnum,
            int cost,
            int cashPoints,
            int winPoints,
            IEnumerable<Symbol> symbols,
            Symbol? extraPointsPerSymbol,
            IEnumerable<CardEnum> requiredCards,
            CardEnum? oneExtraCashPoint = null)
        {
            CardEnum = cardEnum;
            Cost = cost;
            CashPoints = cashPoints;
            WinPoints = winPoints;
            Symbols = symbols ?? Enumerable.Empty<Symbol>();
            ExtraPointsPerSymbol = extraPointsPerSymbol;
            RequiredCards = requiredCards ?? Enumerable.Empty<CardEnum>();
            OneExtraCashPoint = oneExtraCashPoint;
        }

        public static Card Parking => new CardBuilder(CardEnum.Parking, 0, 0, 0).WithSymbols(Symbol.Car, Symbol.Commerce, Symbol.Fountain);
        public static Card House => new CardBuilder(CardEnum.House, 1, 1, 0);
        public static Card TradeCenter => new CardBuilder(CardEnum.TradeCenter, 3, 1, 1).WithSymbols(Symbol.Car);
        public static Card Park => new CardBuilder(CardEnum.Park, 1, 0, 0).WithSymbols(Symbol.Fountain).ExtraWinPoints(Symbol.Fountain);
        public static Card OfficeBuilding => new CardBuilder(CardEnum.OfficeBuilding, 2, 1, 2).Requires(CardEnum.House);
    }
}
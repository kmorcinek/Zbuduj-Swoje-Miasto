using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame
{
    public class CardBuilder
    {
        public CardEnum CardEnum { get; }
        public int Cost { get; }
        public int CashPoints { get; }
        public int WinPoints { get; }
        public IEnumerable<Symbol> Symbols { get; set; }
        public Symbol? ExtraPointsPerSymbol { get; set; }
        public IEnumerable<CardEnum> RequiredCards { get; set; }

        public CardBuilder(
            CardEnum cardEnum,
            int cost,
            int cashPoints,
            int winPoints)
        {
            CardEnum = cardEnum;
            Cost = cost;
            CashPoints = cashPoints;
            WinPoints = winPoints;
        }

        public CardBuilder WithSymbols(params Symbol[] symbols)
        {
            Symbols = symbols;

            return this;
        }

        public CardBuilder ExtraWinPoints(Symbol symbol)
        {
            ExtraPointsPerSymbol = symbol;

            return this;
        }

        public static implicit operator Card(CardBuilder builder)
        {
            return new Card(
                builder.CardEnum,
                builder.Cost,
                builder.CashPoints,
                builder.WinPoints,
                builder.Symbols,
                builder.ExtraPointsPerSymbol,
                builder.RequiredCards);
        }

        public CardBuilder Requires(params CardEnum[] requiredCards)
        {
            RequiredCards = requiredCards;

            return this;
        }

        public CardBuilder OnePerPlayer()
        {
            return this;
        }
    }
}
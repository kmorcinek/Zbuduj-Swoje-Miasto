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
        public CardWithCount CashPerOneCard { get; set; }
        public CardWithCount CashPerEachCard { get; set; }
        public bool IsOnePerPlayer { get; set; }

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

        public CardBuilder(CardEnum cardEnum)
            : this(cardEnum, 0, 0, 0)
        {
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
                builder.RequiredCards,
                builder.CashPerOneCard,
                builder.CashPerEachCard,
                builder.IsOnePerPlayer);
        }

        public CardBuilder WithSymbols(params Symbol[] symbols)
        {
            Symbols = symbols;

            return this;
        }

        /// <summary>
        /// Maksymalnie jedna na gracza
        /// </summary>
        public CardBuilder OnePerPlayer()
        {
            IsOnePerPlayer = true;

            return this;
        }

        /// <summary>
        /// Wymaga kart
        /// </summary>
        public CardBuilder Requires(params CardEnum[] requiredCards)
        {
            RequiredCards = requiredCards;

            return this;
        }

        /// <summary>
        /// Dodatkowy cash point za jeden budynek typu
        /// </summary>
        public CardBuilder ExtraCashPerOneCard(CardEnum card, int count)
        {
            CashPerOneCard = new CardWithCount(card, count);

            return this;
        }

        /// <summary>
        /// Dodatkowy cash point za jeden budynek typu
        /// </summary>
        public CardBuilder ExtraCashPerOneCard(CardEnum card)
        {
            return ExtraCashPerOneCard(card, 1);
        }

        /// <summary>
        /// Dodatkowy cash point za każdy budynek typu
        /// </summary>
        public CardBuilder ExtraCashPerEachCard(CardEnum card)
        {
            return ExtraCashPerEachCard(card, 1);
        }

        /// <summary>
        /// Dodatkowy cash point za każdy budynek typu
        /// </summary>
        public CardBuilder ExtraCashPerEachCard(CardEnum card, int count)
        {
            CashPerEachCard = new CardWithCount(card, count);

            return this;
        }

        /// <summary>
        /// Dodatkowe cash points za symbol
        /// </summary>
        public CardBuilder ExtraCashPoints(Symbol symbol)
        {
            return this;
        }

        /// <summary>
        /// Dodatkowe punty zwyciestwa za symbol
        /// </summary>
        public CardBuilder ExtraWinPoints(Symbol symbol)
        {
            ExtraPointsPerSymbol = symbol;

            return this;
        }
    }
}
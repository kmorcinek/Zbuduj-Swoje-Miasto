namespace KMorcinek.TheCityCardGame
{
    public class CardBuilder
    {
        public CardEnum CardEnum { get; }
        public int Cost { get; }
        public int CashPoints { get; }
        public int WinPoints { get; }
        public Symbol? ExtraPointsPerSymbol { get; set; }

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
                builder.ExtraPointsPerSymbol);
        }
    }
}
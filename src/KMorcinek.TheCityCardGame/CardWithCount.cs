namespace KMorcinek.TheCityCardGame
{
    public class CardWithCount
    {
        public CardEnum Card { get; }
        public int Count { get; }

        public CardWithCount(CardEnum card, int count)
        {
            Card = card;
            Count = count;
        }
    }
}
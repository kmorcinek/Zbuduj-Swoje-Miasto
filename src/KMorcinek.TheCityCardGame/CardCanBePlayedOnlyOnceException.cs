using System.Runtime.Serialization;

namespace KMorcinek.TheCityCardGame
{
    public class CardCanBePlayedOnlyOnceException : CannotPlayCardException
    {
        readonly CardEnum _card;

        public CardCanBePlayedOnlyOnceException(CardEnum card)
        {
            _card = card;
        }

        public override string ToString()
        {
            return $"Card {_card} was already played by player";
        }

        protected CardCanBePlayedOnlyOnceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
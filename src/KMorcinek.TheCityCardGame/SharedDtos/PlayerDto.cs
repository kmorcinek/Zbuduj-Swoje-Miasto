using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame.SharedDtos
{
    public class PlayerDto : IPlayer
    {
        public IEnumerable<Card> CardsInHand { get; set; }
        public IEnumerable<Card> PlayedCards { get; set; }
        public int Points { get; set; }
        public int Turn { get; set; }
    }
}
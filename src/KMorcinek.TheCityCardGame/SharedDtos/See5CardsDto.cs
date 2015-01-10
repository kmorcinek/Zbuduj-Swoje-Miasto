using System.Collections.Generic;

namespace KMorcinek.TheCityCardGame.SharedDtos
{
    public class See5CardsDto
    {
        public IEnumerable<CardEnum> Cards { get; set; }
    }
}
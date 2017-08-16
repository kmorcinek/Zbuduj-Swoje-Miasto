using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class CashPointsCalculator
    {
        public int HowManyCashPoints(IEnumerable<Card> playedCards)
        {
            return playedCards.Sum(c => c.CashPoints);
        }
    }
}
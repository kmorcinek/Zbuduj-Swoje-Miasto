using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class CashPointsCalculator
    {
        public int HowManyCashPoints(IEnumerable<Card> playedCards)
        {
            int simplePoints = playedCards.Sum(c => c.CashPoints);

            int extraPoints = 0;
            foreach (var playedCard in playedCards)
            {
                CardWithCount extraPointsCard = playedCard.CashPerOneCard;
                if (extraPointsCard != null)
                {
                    bool isFound = playedCards.Any(x => x.CardEnum == extraPointsCard.Card);

                    if (isFound)
                    {
                        extraPoints += extraPointsCard.Count;
                    }
                }
            }

            return simplePoints + extraPoints;
        }
    }
}
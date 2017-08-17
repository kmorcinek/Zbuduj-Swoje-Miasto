﻿using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class CashPointsCalculator
    {
        public int HowManyCashPoints(IEnumerable<Card> playedCards)
        {
            int simplePoints = playedCards.Sum(c => c.CashPoints);

            return simplePoints + CalculateCashPerOneCard(playedCards) + CalculateCashPerEachCard(playedCards);
        }

        static int CalculateCashPerOneCard(IEnumerable<Card> playedCards)
        {
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

            return extraPoints;
        }

        static int CalculateCashPerEachCard(IEnumerable<Card> playedCards)
        {
            int extraPoints = 0;
            foreach (var playedCard in playedCards)
            {
                CardWithCount extraPointsCard = playedCard.CashPerEachCard;
                if (extraPointsCard != null)
                {
                    int count = playedCards.Count(x => x.CardEnum == extraPointsCard.Card);

                    extraPoints += extraPointsCard.Count * count;
                }
            }

            return extraPoints;
        }
    }
}
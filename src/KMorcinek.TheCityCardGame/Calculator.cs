using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class Calculator
    {
        public int CalculateWinningPoints(IEnumerable<Card> playedCards)
        {
            int simplyWiningPoints = playedCards.Sum(p => p.WinPoints);

            int extraAnyWinningPoints = 0;// cards.Sum(card => CalcOneCard(card, cards));

            return simplyWiningPoints + extraAnyWinningPoints;
        }

        //private static int CalcOneCard(Card card, IEnumerable<Card> cards)
        //{
        //    return card.AnyExtraWinningPoints.Sum(anyExtraCard =>
        //    {
        //        return cards.Count(regularCard => regularCard.CardEnum == anyExtraCard.Card) * anyExtraCard.Number;
        //    });
        //}
    }
}
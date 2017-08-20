using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class WinningPointsCalculator
    {
        public int Calculate(IEnumerable<Card> playedCards)
        {
            int simplyWiningPoints = playedCards.Sum(p => p.WinPoints);

            int extraPerSymbolPoints = 0;
            foreach (var playedCard in playedCards)
            {
                var extraSymbol = playedCard.ExtraWinPointsPerSymbol;
                if (extraSymbol != null)
                {
                    var sum = playedCards.Sum(x => x.Symbols.Count(y => y == extraSymbol));

                    extraPerSymbolPoints += sum;
                }
            }

            return simplyWiningPoints + extraPerSymbolPoints;
        }
    }
}
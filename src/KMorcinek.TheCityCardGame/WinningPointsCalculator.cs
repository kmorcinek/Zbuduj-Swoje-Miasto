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
                Symbol? extraSymbol = playedCard.ExtraWinPointsPerSymbol;
                if (extraSymbol != null)
                {
                    extraPerSymbolPoints += SymbolsCalculator.CountSymbols(playedCards, extraSymbol.Value);
                }
            }

            return simplyWiningPoints + extraPerSymbolPoints;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class SymbolsCalculator
    {
        public static int CountSymbols(IEnumerable<Card> cards, Symbol symbol)
        {
            return cards.Sum(x => x.Symbols.Count(y => y == symbol));
        }
    }
}
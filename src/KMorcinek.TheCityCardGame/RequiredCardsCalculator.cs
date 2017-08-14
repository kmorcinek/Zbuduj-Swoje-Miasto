using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class RequiredCardsCalculator
    {
        public bool CanBePlayed(Card card, Player player)// IEnumerable<Card> playedCards)
        {
            // TODO: test checking if played card is not counted as discarded
            bool simpleBuildingMet = card.Cost < player.CardsInHand.Count() - 1;

            //bool cardsRequirementsMet = IsCardRequirementMet(card.RequiredCards, playedCards);

            return simpleBuildingMet;// && cardsRequirementsMet;
        }

        private static bool IsCardRequirementMet(IEnumerable<RequiredCard> requiredCards, IEnumerable<Card> playedCards)
        {
            return requiredCards.All(requiredCard =>
            {
                return playedCards.Count(p => p.CardEnum == requiredCard.Card) > requiredCard.Number;
            });
        }

        private static bool IsSimplyBuildingMet(int requiredBuildingPoints, IEnumerable<Card> playedCards)
        {
            if (requiredBuildingPoints == 0)
            {
                return true;
            }
            
            return playedCards.Sum(p => p.Cost) > requiredBuildingPoints;
        }
    }
}
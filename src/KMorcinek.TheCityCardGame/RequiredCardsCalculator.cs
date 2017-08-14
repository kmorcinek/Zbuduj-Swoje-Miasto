using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class RequiredCardsCalculator
    {
        public bool CanBePlayed(Card card, Player player)
        {
            // TODO: test checking if played card is not counted as discarded
            bool simpleBuildingMet = card.Cost <= player.CardsInHand.Count() - 1;

            bool cardsRequirementsMet = IsCardRequirementMet(card.RequiredCards, player.PlayedCards);

            return simpleBuildingMet && cardsRequirementsMet;
        }

        static bool IsCardRequirementMet(IEnumerable<CardEnum> requiredCards, IEnumerable<Card> playedCards)
        {
            if (requiredCards.Any() == false)
            {
                return true;
            }

            return playedCards.Any(x => requiredCards.Contains(x.CardEnum));
        }
    }
}
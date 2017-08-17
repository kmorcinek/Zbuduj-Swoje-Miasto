using System.Collections.Generic;
using System.Linq;

namespace KMorcinek.TheCityCardGame
{
    public class RequiredCardsCalculator
    {
        public void EnsureCanBePlayed(Card card, Player player)
        {
            bool isCardFree = card.Cost == 0;

            // TODO: test checking if played card is not counted as discarded
            bool simpleBuildingMet = isCardFree || card.Cost <= player.CardsInHand.Count() - 1;

            if (simpleBuildingMet == false)
            {
                throw new CannotPlayCardException("Cannot afford to play this card");
            }

            EnsureCardRequirementMet(card.RequiredCards, player.PlayedCards);
        }

        public bool CanBePlayed(Card card, Player player)
        {
            try
            {
                EnsureCanBePlayed(card, player);

                return true;
            }
            catch (CannotPlayCardException)
            {
                return false;
            }
        }

        static void EnsureCardRequirementMet(IEnumerable<CardEnum> requiredCards, IEnumerable<Card> playedCards)
        {
            if (requiredCards.Any() == false)
            {
                return;
            }

            bool isAnyRequiredCard = playedCards.Any(x => requiredCards.Contains(x.CardEnum));
            if (isAnyRequiredCard == false)
            {
                throw new CannotPlayCardException();
            }
        }
    }
}
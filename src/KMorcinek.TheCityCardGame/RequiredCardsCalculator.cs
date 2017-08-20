using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace KMorcinek.TheCityCardGame
{
    public class RequiredCardsCalculator
    {
        public void EnsureCanBePlayed(Card card, IPlayer player)
        {
            bool isCardFree = card.Cost == 0;

            // TODO: test checking if played card is not counted as discarded
            bool simpleBuildingMet = isCardFree || card.Cost <= player.CardsInHand.Count() - 1;

            if (simpleBuildingMet == false)
            {
                throw new CannotPlayCardException("Cannot afford to play this card");
            }

            EnsureCardRequirementMet(card.RequiredCards, player.PlayedCards);

            EnsureCardThatCanBePlayedOnceWasNotPlayed(card, player.PlayedCards);
        }

        public bool CanBePlayed(Card card, IPlayer player)
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

        static void EnsureCardThatCanBePlayedOnceWasNotPlayed(Card card, IEnumerable<Card> playedCards)
        {
            if (card.IsOnePerPlayer == false)
            {
                return;
            }

            if (playedCards.Any(x => x.CardEnum == card.CardEnum))
            {
                throw new CardCanBePlayedOnlyOnceException(card.CardEnum);
            }
        }
    }
}
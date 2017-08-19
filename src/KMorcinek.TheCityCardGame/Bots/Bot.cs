using System;
using System.Collections.Generic;
using System.Linq;
using KMorcinek.TheCityCardGame.SharedDtos;

namespace KMorcinek.TheCityCardGame.Bots
{
    public class Bot : ClientBase
    {
        public Bot()
            : this(new DisconnectedGame(1), TimeSpan.Zero)
        {
        }

        protected Bot(IGameServer gameServer, TimeSpan waitForMove)
            : base(gameServer, waitForMove)
        {
        }

        protected override void MakeNextMove(IPlayer player)
        {
            if (PlayArchitect(player))
            {
                return;
            }

            if (PlayFirstCard(player))
            {
                return;
            }

            WaitAndTakeCard();
        }

        bool PlayArchitect(IPlayer player)
        {
            if (IsArchitectPlayed(player))
            {
                return false;
            }

            GameServer.PlayArchitect(PlayerIndex);

            return true;
        }

        bool PlayFirstCard(IPlayer player)
        {
            Card[] cardsInHand = player.CardsInHand.ToArray();

            IEnumerable<Card> playableCards = cardsInHand.Where(x => CanBePlayed(x, player));

            playableCards = new CashPointsCalculator().HowManyCashPoints(player.PlayedCards) > 2
                ? playableCards.OrderByDescending(x => x.WinPoints)
                : playableCards.OrderByDescending(x => x.CashPoints);

            Card card = playableCards.FirstOrDefault();

            if (card == null)
            {
                return false;
            }

            PlayCard(card, cardsInHand);

            return true;
        }

        void PlayCard(Card card, Card[] cardsInHand)
        {
            int cardIndexToPlay = Array.IndexOf(cardsInHand, card);
            int[] cardsToDiscard = GetCardsToDiscard(card.Cost, cardIndexToPlay);

            GameServer.PlayCard(PlayerIndex, cardIndexToPlay, cardsToDiscard);
        }

        public static int[] GetCardsToDiscard(int cost, int cardIndexToPlay)
        {
            // Take first "n" indexes different that cardIndex
            var cardsToDiscard = new List<int>();

            int i = 0;
            while (cardsToDiscard.Count < cost)
            {
                if (i != cardIndexToPlay)
                {
                    cardsToDiscard.Add(i);
                }

                i++;
            }

            return cardsToDiscard.ToArray();
        }

        static bool CanBePlayed(Card card, IPlayer player)
        {
            return card.Cost + 1 <= player.CardsInHand.Count() && new RequiredCardsCalculator().CanBePlayed(card, player);
        }

        void WaitAndTakeCard()
        {
            See5CardsDto see5CardsDto = GameServer.See5Cards(PlayerIndex);

            CardEnum card = see5CardsDto.Cards.First();
            Console.WriteLine($"Chosen card: {card}");

            GameServer.TakeOneCard(PlayerIndex, card);
        }
    }
}
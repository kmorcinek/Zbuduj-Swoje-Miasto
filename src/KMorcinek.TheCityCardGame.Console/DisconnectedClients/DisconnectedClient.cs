using System;
using System.Linq;
using KMorcinek.TheCityCardGame.SharedDtos;

namespace KMorcinek.TheCityCardGame.ConsoleUI.DisconnectedClients
{
    public class DisconnectedClient : ClientBase
    {
        public DisconnectedClient()
            : this(DisconnectedGame.Instance, TimeSpan.FromSeconds(1))
        {
        }

        protected DisconnectedClient(IGameServer game, TimeSpan waitForMove)
            : base(game, waitForMove)
        {
        }

        protected override void MakeNextMove(IPlayer player)
        {
            using (new ConsoleColorChanger(Game.Colors[PlayerIndex]))
            {
                Game.ShowCards(player);

                bool isArchitectPlayed = IsArchitectPlayed(player);

                MoveAndCardIndex move = GetMove(isArchitectPlayed);

                switch (move.Move)
                {
                    case Move.PlayCard:
                        int cardIndexToPlay = move.CardIndex ?? Game.GetCardIndexToPlay();
                        int[] cardsToDiscard = Game.GetCardIndexesToDiscard();

                        Card playedCard = player.CardsInHand.ElementAt(cardIndexToPlay);

                        GameServer.PlayCard(PlayerIndex, cardIndexToPlay, cardsToDiscard);

                        Game.ShowPlayedCard(playedCard);
                        break;
                    case Move.Architect:
                        GameServer.PlayArchitect(PlayerIndex);
                        Console.WriteLine("Architect played");
                        break;
                    case Move.WaitAndTakeCard:
                        WaitAndTakeCard();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        void WaitAndTakeCard()
        {
            See5CardsDto see5CardsDto = GameServer.See5Cards(PlayerIndex);

            Game.WriteCards(see5CardsDto.Cards.Select(Deck.GetCard));
            Console.Write("Choose card index to take into hand:");

            string line = Console.ReadLine();
            int cardIndex = int.Parse(line);
            CardEnum card = see5CardsDto.Cards.ElementAt(cardIndex);

            GameServer.TakeOneCard(PlayerIndex, card);
        }

        static MoveAndCardIndex GetMove(bool isArchitectPlayed)
        {
            string architectAction = "";

            if (isArchitectPlayed == false)
            {
                architectAction = "A - architect, ";
            }

            Console.Write($"Choose action: {architectAction}P - play card, W - Wait and check 5 card and take 1: ");

            string moveAsString = Console.ReadLine().Trim().ToUpperInvariant();

            switch (moveAsString)
            {
                case "A":
                    return new MoveAndCardIndex(Move.Architect);
                case "P":
                    return new MoveAndCardIndex(Move.PlayCard);
                case "W":
                    return new MoveAndCardIndex(Move.WaitAndTakeCard);
                default:
                    int value;
                    if (int.TryParse(moveAsString, out value))
                    {
                        return new MoveAndCardIndex(Move.PlayCard, value);
                    }

                    throw new NotImplementedException("missing guards");
            }
        }

        class MoveAndCardIndex
        {
            public Move Move { get; }
            public int? CardIndex { get; }

            public MoveAndCardIndex(Move move)
            {
                Move = move;
            }

            public MoveAndCardIndex(Move move, int cardIndex)
                : this(move)
            {
                CardIndex = cardIndex;
            }
        }
    }
}
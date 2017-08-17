using System;
using System.Linq;
using System.Threading.Tasks;
using KMorcinek.TheCityCardGame.SharedDtos;
using Serilog;

namespace KMorcinek.TheCityCardGame.ConsoleUI.DisconnectedClients
{
    public class DisconnectedClient
    {
        readonly IGameServer _game;

        int _playerIndex;

        public DisconnectedClient()
            : this(DisconnectedGame.Instance)
        {
        }

        protected DisconnectedClient(IGameServer game)
        {
            _game = game;
        }

        public void Start()
        {
            int playerIndex = _game.Connect();

            Log.Information("Client get {playerIndex}", playerIndex);

            _playerIndex = playerIndex;

            while (true)
            {
                IPlayer player = _game.GetState(_playerIndex);

                if (player != null)
                {
                    if (player.Points >= Player.PointsGoal)
                    {
                        Log.Information("Game took {turns} turns", player.Turn);
                        return;
                    }

                    MakeNextMove(player);
                }

                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            }
        }

        void MakeNextMove(IPlayer player)
        {
            using (new ConsoleColorChanger(Game.Colors[_playerIndex]))
            {
                Game.ShowCards(player);

                bool isArchitectPlayed = player.PlayedCards.Any(x => x.CardEnum == CardEnum.Architect);

                MoveAndCardIndex move = GetMove(isArchitectPlayed);

                switch (move.Move)
                {
                    case Move.PlayCard:
                        int cardIndexToPlay = move.CardIndex ?? Game.GetCardIndexToPlay();
                        int[] cardsToDiscard = Game.GetCardIndexesToDiscard();

                        Card playedCard = player.CardsInHand.ElementAt(cardIndexToPlay);

                        _game.PlayCard(_playerIndex, cardIndexToPlay, cardsToDiscard);

                        Game.ShowPlayedCard(playedCard);
                        break;
                    case Move.Architect:
                        _game.PlayArchitect(_playerIndex);
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
            See5CardsDto see5CardsDto = _game.See5Cards(_playerIndex);

            Game.WriteCards(see5CardsDto.Cards.Select(Deck.GetCard));
            Console.Write("Choose card index to take into hand:");

            string line = Console.ReadLine();
            int cardIndex = int.Parse(line);
            CardEnum card = see5CardsDto.Cards.ElementAt(cardIndex);

            _game.TakeOneCard(_playerIndex, card);
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
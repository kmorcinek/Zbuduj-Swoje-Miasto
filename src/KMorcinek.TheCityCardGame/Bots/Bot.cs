using System;
using System.Linq;
using System.Threading.Tasks;
using KMorcinek.TheCityCardGame.SharedDtos;
using Serilog;

namespace KMorcinek.TheCityCardGame.Bots
{
    public class Bot
    {
        readonly IGameServer _game;

        int _playerIndex;

        public Bot()
            : this(DisconnectedGame.Instance)
        {
        }

        protected Bot(IGameServer game)
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
                TryMakeNextMove();

                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            }
        }

        void TryMakeNextMove()
        {
            IPlayer player = _game.GetState(_playerIndex);

            if (player != null)
            {
                MakeNextMove(player);
            }
        }

        void MakeNextMove(IPlayer player)
        {
            WaitAndTakeCard();
        }

        void WaitAndTakeCard()
        {
            See5CardsDto see5CardsDto = _game.See5Cards(_playerIndex);

            // TODO: write output
            // Game.WriteCards(see5CardsDto.Cards.Select(Deck.GetCard));
            CardEnum card = see5CardsDto.Cards.First();
            Console.WriteLine($"Choosen card: {card}");

            _game.TakeOneCard(_playerIndex, card);
        }
    }
}
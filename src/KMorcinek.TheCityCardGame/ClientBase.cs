using System;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace KMorcinek.TheCityCardGame
{
    public abstract class ClientBase
    {
        readonly IGameServer _game;
        readonly TimeSpan _waitForMove;
        int _playerIndex;

        protected ClientBase(IGameServer game, TimeSpan waitForMove)
        {
            _game = game;
            _waitForMove = waitForMove;
        }

        protected IGameServer GameServer => _game;
        protected int PlayerIndex => _playerIndex;

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
                        Log.Information("====> Game took {turns} turns", player.Turn);
                        return;
                    }

                    MakeNextMove(player);
                }

                Task.Delay(_waitForMove).Wait();
            }
        }

        protected abstract void MakeNextMove(IPlayer player);

        protected static bool IsArchitectPlayed(IPlayer player)
        {
            return player.PlayedCards.Any(x => x.CardEnum == CardEnum.Architect);
        }
    }
}
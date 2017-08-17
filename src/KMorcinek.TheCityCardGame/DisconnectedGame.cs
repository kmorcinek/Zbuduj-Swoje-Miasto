using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Serilog;

namespace KMorcinek.TheCityCardGame
{
    public class DisconnectedGame : IGameServer
    {
        const int TotalPlayersCount = 2;

        public static DisconnectedGame Instance { get; } = new DisconnectedGame();

        readonly IMapper _mapper = AutoMapperConfig.GetMapper();
        readonly List<int> _connectedClients = new List<int>();
        readonly object _syncRoot = new object();
        Board _board;
        bool _isGameStarted;
        int _waitingForPlayerIndex;

        public int Connect()
        {
            lock (_syncRoot)
            {
                int count = _connectedClients.Count;

                // Simulate adding a client, in future it can be name and other info
                _connectedClients.Add(count);

                if (_connectedClients.Count == TotalPlayersCount)
                {
                    _board = Board.StartGame(TotalPlayersCount);

                    _isGameStarted = true;
                    Log.Information("Game is started with {TotalPlayersCount} player", TotalPlayersCount);
                }

                return count;
            }
        }

        public IPlayer GetState(int playerIndex)
        {
            if (_isGameStarted == false)
            {
                return null;
            }

            if (playerIndex != _waitingForPlayerIndex)
            {
                return null;
            }

            return _mapper.Map<PlayerDto>(_board.Players.ElementAt(playerIndex));
        }

        public void PlayCard(int playerIndex, int cardIndexToPlay, int[] cardsToDiscard)
        {
            lock (_syncRoot)
            {
                _board.PlayCard(playerIndex, cardIndexToPlay, cardsToDiscard);

                JumbToNextPlayer();
            }
        }

        public void PlayArchitect(int playerIndex)
        {
            lock (_syncRoot)
            {
                _board.PlayArchitect(playerIndex);

                JumbToNextPlayer();
            }
        }

        void JumbToNextPlayer()
        {
            _waitingForPlayerIndex++;

            if (_waitingForPlayerIndex >= _connectedClients.Count)
            {
                _waitingForPlayerIndex = 0;
            }
        }
    }
}
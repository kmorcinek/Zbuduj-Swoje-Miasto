using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace KMorcinek.TheCityCardGame.ConsoleUI.DisconnectedClients
{
    public class DisconnectedGame
    {
        public static DisconnectedGame Instance = new DisconnectedGame();

        readonly List<int> _connectedClients = new List<int>();
        Board _board;
        bool _isGameStarted;
        int _waitingForPlayerIndex;
        readonly object _syncRoot = new object();
        readonly IMapper _mapper = AutoMapperConfig.GetMapper();

        DisconnectedGame()
        {
        }

        public int Connect()
        {
            lock (_syncRoot)
            {
                int count = _connectedClients.Count;

                // Simulate adding a client, in future it can be name and other info
                _connectedClients.Add(count);

                int totalPlayersCount = 2;
                if (_connectedClients.Count == totalPlayersCount)
                {
                    _board = Game.StartGame(totalPlayersCount);

                    _isGameStarted = true;
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

                _waitingForPlayerIndex++;

                if (_waitingForPlayerIndex >= _connectedClients.Count)
                {
                    _waitingForPlayerIndex = 0;
                }
            }
        }
    }
}
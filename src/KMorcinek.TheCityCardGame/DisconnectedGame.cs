using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KMorcinek.TheCityCardGame.SharedDtos;
using Serilog;

namespace KMorcinek.TheCityCardGame
{
    public class DisconnectedGame : IGameServer
    {
        public const int TotalPlayersCount = 2;

        public static DisconnectedGame Instance { get; } = new DisconnectedGame(TotalPlayersCount);

        readonly IMapper _mapper = AutoMapperConfig.GetMapper();
        readonly List<int> _connectedClients = new List<int>();
        readonly object _syncRoot = new object();
        readonly int _totalPlayersCount;
        Board _board;
        bool _isGameStarted;
        int _waitingForPlayerIndex;
        Card[] _drawAndSee5Cards;

        public DisconnectedGame(int totalPlayersCount)
        {
            _totalPlayersCount = totalPlayersCount;
        }

        public int Connect()
        {
            lock (_syncRoot)
            {
                int count = _connectedClients.Count;

                // Simulate adding a client, in future it can be name and other info
                _connectedClients.Add(count);

                if (_connectedClients.Count == _totalPlayersCount)
                {
                    _board = Board.StartGame(_totalPlayersCount);

                    _isGameStarted = true;
                    Log.Information("Game is started with {TotalPlayersCount} players", _totalPlayersCount);
                }

                return count;
            }
        }

        public IPlayer GetState(int playerIndex)
        {
            if (IsWrongCall(playerIndex))
            {
                return null;
            }

            return _mapper.Map<PlayerDto>(_board.Players.ElementAt(playerIndex));
        }

        bool IsWrongCall(int playerIndex)
        {
            return _isGameStarted == false || playerIndex != _waitingForPlayerIndex;
        }

        void EnsureCanPlay(int playerIndex)
        {
            if (IsWrongCall(playerIndex))
            {
                throw new InvalidOperationException("Cannot play card now");
            }
        }

        public void PlayCard(int playerIndex, int cardIndexToPlay, int[] cardsToDiscard)
        {
            EnsureCanPlay(playerIndex);

            lock (_syncRoot)
            {
                _board.PlayCard(playerIndex, cardIndexToPlay, cardsToDiscard);

                JumpToNextPlayer();
            }
        }

        public void PlayArchitect(int playerIndex)
        {
            EnsureCanPlay(playerIndex);

            lock (_syncRoot)
            {
                _board.PlayArchitect(playerIndex);

                JumpToNextPlayer();
            }
        }

        public See5CardsDto See5Cards(int playerIndex)
        {
            EnsureCanPlay(playerIndex);

            lock (_syncRoot)
            {
                // TODO: implemet 5 cards shown to who per user, and disallow brute force choosing cards
                _drawAndSee5Cards = _board.DrawAndSee5Cards().ToArray();

                return new See5CardsDto
                {
                    Cards = _drawAndSee5Cards.Select(x => x.CardEnum)
                };
            }
        }

        public void TakeOneCard(int playerIndex, CardEnum card)
        {
            EnsureCanPlay(playerIndex);

            lock (_syncRoot)
            {
                // TODO: implemet 5 cards shown to who
                Card choosenCard = _drawAndSee5Cards.First(x => x.CardEnum == card);

                _board.TakeOneCard(playerIndex, choosenCard);

                JumpToNextPlayer();
            }
        }

        void JumpToNextPlayer()
        {
            Log.Debug("JumpToNextPlayer()");

            _waitingForPlayerIndex++;

            if (_waitingForPlayerIndex >= _connectedClients.Count)
            {
                _waitingForPlayerIndex = 0;
            }
        }
    }
}
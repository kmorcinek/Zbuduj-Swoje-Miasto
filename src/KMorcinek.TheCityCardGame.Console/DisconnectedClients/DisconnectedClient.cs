using System;
using System.Linq;
using System.Threading.Tasks;
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
            using (new ConsoleColorChanger(Game.Colors[_playerIndex]))
            {
                Game.ShowCards(player);

                int cardIndexToPlay = Game.GetCardIndexToPlay();
                int[] cardsToDiscard = Game.GetCardIndexesToDiscard();

                Card playedCard = player.CardsInHand.ElementAt(cardIndexToPlay);

                _game.PlayCard(_playerIndex, cardIndexToPlay, cardsToDiscard);

                Game.ShowPlayedCard(playedCard); 
            }
        }
    }
}
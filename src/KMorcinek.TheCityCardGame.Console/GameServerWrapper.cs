using KMorcinek.TheCityCardGame.SharedDtos;
using Refit;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    public class GameServerWrapper : IGameServer
    {
        public const string ServerUrl = "http://localhost:7820/api/game";
        readonly IServerApi _serverApi = RestService.For<IServerApi>(ServerUrl);

        public int Connect()
        {
            // TODO: Check how Refit lib is treating error from Server
            return _serverApi.Conntect().Result;
        }

        public IPlayer GetState(int playerIndex)
        {
            return _serverApi.GetState(playerIndex).Result;
        }

        public void PlayCard(int playerIndex, int cardIndexToPlay, int[] cardsToDiscard)
        {
            PlayCardDto playCardDto = new PlayCardDto(cardIndexToPlay, cardsToDiscard);

            _serverApi.PlayCard(playerIndex, playCardDto).Wait();
        }

        public void PlayArchitect(int playerIndex)
        {
            _serverApi.PlayArchitect(playerIndex).Wait();
        }

        public See5CardsDto See5Cards(int playerIndex)
        {
            return _serverApi.See5Cards(playerIndex).Result;
        }

        public void TakeOneCard(int playerIndex, CardEnum card)
        {
            _serverApi.TakeOneCard(playerIndex, (int)card).Wait();
        }
    }
}
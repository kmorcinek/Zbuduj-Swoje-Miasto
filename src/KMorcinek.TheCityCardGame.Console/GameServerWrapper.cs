using RestSharp;

namespace KMorcinek.TheCityCardGame.ConsoleUI
{
    public class GameServerWrapper : IGameServer
    {
        const string ServerUrl = "http://localhost:7820/api/game";

        public int Connect()
        {
            var client = new RestClient(ServerUrl);
            var request = new RestRequest("connect", Method.GET);

            return client.Execute<int>(request).Data;
        }

        public IPlayer GetState(int playerIndex)
        {
            return null;
        }

        public void PlayCard(int playerIndex, int cardIndexToPlay, int[] cardsToDiscard)
        {
            throw new System.NotImplementedException();
        }
    }
}